namespace Readmanga
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameManga = new System.Windows.Forms.TextBox();
            this.numTom = new System.Windows.Forms.NumericUpDown();
            this.numChapterLast = new System.Windows.Forms.NumericUpDown();
            this.Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.createPdf = new System.Windows.Forms.CheckBox();
            this.deletePic = new System.Windows.Forms.CheckBox();
            this.DownloadAll = new System.Windows.Forms.CheckBox();
            this.rmRadio = new System.Windows.Forms.RadioButton();
            this.mmRadio = new System.Windows.Forms.RadioButton();
            this.numChapterFirst = new System.Windows.Forms.NumericUpDown();
            this.newMethodDownload = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numTom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChapterLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChapterFirst)).BeginInit();
            this.SuspendLayout();
            // 
            // nameManga
            // 
            this.nameManga.Location = new System.Drawing.Point(15, 49);
            this.nameManga.Name = "nameManga";
            this.nameManga.Size = new System.Drawing.Size(188, 20);
            this.nameManga.TabIndex = 1;
            // 
            // numTom
            // 
            this.numTom.Location = new System.Drawing.Point(15, 88);
            this.numTom.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTom.Name = "numTom";
            this.numTom.Size = new System.Drawing.Size(188, 20);
            this.numTom.TabIndex = 2;
            this.numTom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numChapterLast
            // 
            this.numChapterLast.Location = new System.Drawing.Point(113, 140);
            this.numChapterLast.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numChapterLast.Name = "numChapterLast";
            this.numChapterLast.Size = new System.Drawing.Size(90, 20);
            this.numChapterLast.TabIndex = 3;
            this.numChapterLast.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChapterLast.ValueChanged += new System.EventHandler(this.NumChapterLast_ValueChanged);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(15, 299);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(188, 23);
            this.Start.TabIndex = 6;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Название манги или ссылка на неё";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Номер тома";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "С какой и до какой главы \r\nскачивать мангу";
            // 
            // createPdf
            // 
            this.createPdf.AutoSize = true;
            this.createPdf.Location = new System.Drawing.Point(15, 167);
            this.createPdf.Name = "createPdf";
            this.createPdf.Size = new System.Drawing.Size(181, 30);
            this.createPdf.TabIndex = 11;
            this.createPdf.Text = "Создать pdf после скачивания\r\n(изображения НЕ удалятся)";
            this.createPdf.UseVisualStyleBackColor = true;
            // 
            // deletePic
            // 
            this.deletePic.AutoSize = true;
            this.deletePic.Location = new System.Drawing.Point(15, 203);
            this.deletePic.Name = "deletePic";
            this.deletePic.Size = new System.Drawing.Size(140, 30);
            this.deletePic.TabIndex = 12;
            this.deletePic.Text = "Удалить изображения\r\n(создастся pdf файл)";
            this.deletePic.UseVisualStyleBackColor = true;
            // 
            // DownloadAll
            // 
            this.DownloadAll.AutoSize = true;
            this.DownloadAll.Location = new System.Drawing.Point(15, 240);
            this.DownloadAll.Name = "DownloadAll";
            this.DownloadAll.Size = new System.Drawing.Size(123, 17);
            this.DownloadAll.TabIndex = 13;
            this.DownloadAll.Text = "Скачать всю мангу";
            this.DownloadAll.UseVisualStyleBackColor = true;
            this.DownloadAll.CheckedChanged += new System.EventHandler(this.DownloadAll_CheckedChanged);
            // 
            // rmRadio
            // 
            this.rmRadio.AutoSize = true;
            this.rmRadio.Checked = true;
            this.rmRadio.Location = new System.Drawing.Point(15, 13);
            this.rmRadio.Name = "rmRadio";
            this.rmRadio.Size = new System.Drawing.Size(83, 17);
            this.rmRadio.TabIndex = 14;
            this.rmRadio.TabStop = true;
            this.rmRadio.Text = "Readmanga";
            this.rmRadio.UseVisualStyleBackColor = true;
            // 
            // mmRadio
            // 
            this.mmRadio.AutoSize = true;
            this.mmRadio.Location = new System.Drawing.Point(104, 13);
            this.mmRadio.Name = "mmRadio";
            this.mmRadio.Size = new System.Drawing.Size(77, 17);
            this.mmRadio.TabIndex = 15;
            this.mmRadio.TabStop = true;
            this.mmRadio.Text = "Mintmanga";
            this.mmRadio.UseVisualStyleBackColor = true;
            // 
            // numChapterFirst
            // 
            this.numChapterFirst.Location = new System.Drawing.Point(15, 140);
            this.numChapterFirst.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numChapterFirst.Name = "numChapterFirst";
            this.numChapterFirst.Size = new System.Drawing.Size(90, 20);
            this.numChapterFirst.TabIndex = 16;
            this.numChapterFirst.ValueChanged += new System.EventHandler(this.NumChapterFirst_ValueChanged);
            // 
            // newMethodDownload
            // 
            this.newMethodDownload.AutoSize = true;
            this.newMethodDownload.Location = new System.Drawing.Point(15, 263);
            this.newMethodDownload.Name = "newMethodDownload";
            this.newMethodDownload.Size = new System.Drawing.Size(176, 30);
            this.newMethodDownload.TabIndex = 17;
            this.newMethodDownload.Text = "Изменить метод скачивания \r\n(не будет создан pdf)";
            this.newMethodDownload.UseVisualStyleBackColor = true;
            this.newMethodDownload.CheckedChanged += new System.EventHandler(this.NewMethodDownload_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 335);
            this.Controls.Add(this.newMethodDownload);
            this.Controls.Add(this.numChapterFirst);
            this.Controls.Add(this.mmRadio);
            this.Controls.Add(this.rmRadio);
            this.Controls.Add(this.DownloadAll);
            this.Controls.Add(this.deletePic);
            this.Controls.Add(this.createPdf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.numChapterLast);
            this.Controls.Add(this.numTom);
            this.Controls.Add(this.nameManga);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "DownloadManga";
            ((System.ComponentModel.ISupportInitialize)(this.numTom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChapterLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChapterFirst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nameManga;
        private System.Windows.Forms.NumericUpDown numTom;
        private System.Windows.Forms.NumericUpDown numChapterLast;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox createPdf;
        private System.Windows.Forms.CheckBox deletePic;
        private System.Windows.Forms.CheckBox DownloadAll;
        private System.Windows.Forms.RadioButton rmRadio;
        private System.Windows.Forms.RadioButton mmRadio;
        private System.Windows.Forms.NumericUpDown numChapterFirst;
        private System.Windows.Forms.CheckBox newMethodDownload;
    }
}

