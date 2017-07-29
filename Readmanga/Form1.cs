using iTextSharp.text;
using iTextSharp.text.pdf;
using Readmanga.Core;
using Readmanga.Core.Mintmanga;
using Readmanga.Core.Readmanga;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Readmanga
{
    public partial class Form1 : Form
    {
        ParserWorker<string []> parser;
        String path, path_file = Directory.GetCurrentDirectory(), replacement = "$2";
        String[] images;
        Regex rgx = new Regex(@"(.*manga\.\w+\/)(\w+)(.*)", RegexOptions.IgnoreCase);
        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(new RmParser());
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }
        private void Parser_OnNewData(object arg1, string[] arg2, int num_chapter, int num_tom)
        {
            int j = 0;
            images = new String[arg2.Length / 6];
            for (int i = 0; i < arg2.Length; i += 6)
            {
                try
                {
                    string str = arg2[i + 1] + arg2[i] + arg2[i + 2];
                    path = $"{path_file}\\Manga\\{nameManga.Text}\\{num_tom}\\{num_chapter}";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (WebClient client = new WebClient())
                    {
                        if (newMethodDownload.Checked)
                        {
                            client.DownloadFileAsync(new Uri(str), $"{path}\\{nameManga.Text}_{num_tom}_{num_chapter}_{j}.jpg");
                            j++;
                        }
                        else
                        {
                            client.DownloadFile(new Uri(str), $"{path}\\{nameManga.Text}_{num_tom}_{num_chapter}_{j}.jpg");
                            images[j] = $"{path}\\{nameManga.Text}_{num_tom}_{num_chapter}_{j}.jpg";
                            j++;
                        }
                    }
                    if (i > (arg2.Length - 8))
                    {
                        if (deletePic.Checked)
                        {
                            ImgToPdf($"{path_file}\\Manga\\{nameManga.Text}\\{nameManga.Text}_{num_tom}_{num_chapter}.pdf", images);
                            Directory.Delete($"{path_file}\\Manga\\{nameManga.Text}\\{num_tom}", true);
                        }
                        else if (createPdf.Checked)
                        {
                            ImgToPdf($"{path_file}\\Manga\\{nameManga.Text}\\{nameManga.Text}_{num_tom}_{num_chapter}.pdf", images);
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    break;
                }
            }
        }
        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("All works done!");
            createPdf.Enabled = true;
            deletePic.Enabled = true;
            DownloadAll.Enabled = true;
            newMethodDownload.Enabled = true;
            nameManga.Enabled = true;
            numChapterFirst.Enabled = true;
            numChapterLast.Enabled = true;
            numTom.Enabled = true;
            Start.Enabled = true;
            rmRadio.Visible = true;
            mmRadio.Visible = true;
        }
        private void Start_Click(object sender, EventArgs e)
        {
            nameManga.Enabled = false;
            createPdf.Enabled = false;
            deletePic.Enabled = false;
            DownloadAll.Enabled = false;
            newMethodDownload.Enabled = false;
            numChapterFirst.Enabled = false;
            numChapterLast.Enabled = false;
            numTom.Enabled = false;
            Start.Enabled = false;
            if (rgx.IsMatch(nameManga.Text))
            {
                nameManga.Text = rgx.Replace(nameManga.Text, replacement);
            }
            if (rmRadio.Checked)
            {
                mmRadio.Visible = false;
                parser.Settings = new RmSettings(nameManga.Text, (int)numTom.Value, (int)numChapterLast.Value, (int)numChapterFirst.Value, DownloadAll.Checked);
            }
            else
            {
                rmRadio.Visible = false;
                parser.Settings = new MmSettings(nameManga.Text, (int)numTom.Value, (int)numChapterLast.Value, (int)numChapterFirst.Value, DownloadAll.Checked);
            }
            parser.Start();
        }
        private void NumChapterFirst_ValueChanged(object sender, EventArgs e)
        {
            if (numChapterFirst.Value > numChapterLast.Value)
            {
                numChapterLast.Value = numChapterFirst.Value;
            }
        }
        private void NumChapterLast_ValueChanged(object sender, EventArgs e)
        {
            if (numChapterFirst.Value > numChapterLast.Value)
            {
                numChapterFirst.Value = numChapterLast.Value;
            }
        }
        private void NewMethodDownload_CheckedChanged(object sender, EventArgs e)
        {
            if (newMethodDownload.Checked)
            {
                createPdf.Enabled = false;
                deletePic.Enabled = false;
                createPdf.Checked = false;
                deletePic.Checked = false;
            }
            else
            {
                createPdf.Enabled = true;
                deletePic.Enabled = true;
            }
            
        }
        private void ImgToPdf(string folder, string[] images)
        {
            var document = new Document(PageSize.A4, 25, 25, 25, 25);
            using (var stream = new FileStream(folder, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                foreach (var image in images)
                {
                    using (var imageStream = new FileStream(image, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var page = Image.GetInstance(imageStream);
                        float width = page.Width;
                        float height = page.Height;

                        if (width < height)
                        {
                            document.SetPageSize(iTextSharp.text.PageSize.A4);
                        }
                        else
                        {
                            document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                        }
                        document.NewPage();
                        if (width < height)
                        {
                            if (page.Height > iTextSharp.text.PageSize.A4.Height - 25)
                            {
                                page.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                            }
                            else if (page.Width > iTextSharp.text.PageSize.A4.Width - 25)
                            {
                                page.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                            }
                        }
                        else
                        {
                            if (page.Height > iTextSharp.text.PageSize.A4.Height - 25)
                            {
                                page.ScaleToFit(iTextSharp.text.PageSize.A4.Height - 25, iTextSharp.text.PageSize.A4.Width - 25);
                            }
                            else if (page.Width > iTextSharp.text.PageSize.A4.Width - 25)
                            {
                                page.ScaleToFit(iTextSharp.text.PageSize.A4.Height - 25, iTextSharp.text.PageSize.A4.Width - 25);
                            }
                        }
                        page.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                        document.Add(page);
                    }
                }
                document.Close();
            }
        }
        private void DownloadAll_CheckedChanged(object sender, EventArgs e)
        {
            if (DownloadAll.Checked)
            {
                label2.Visible = false;
                label3.Visible = false;
                numTom.Visible = false;
                numTom.Value = 0;
                numChapterFirst.Visible = false;
                numChapterFirst.Value = 0;
                numChapterLast.Visible = false;
                numChapterLast.Value = 0;

            }
            else
            {
                label2.Visible = true;
                label3.Visible = true;
                numTom.Visible = true;
                numTom.Value = 1;
                numChapterFirst.Visible = true;
                numChapterFirst.Value = 0;
                numChapterLast.Visible = true;
                numChapterLast.Value = 1;
            }
        }
    }
}