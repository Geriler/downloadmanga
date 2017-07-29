namespace Readmanga.Core.Mintmanga
{
    class MmSettings : IParserSettings
    {
        public MmSettings(string nameManga, int numTom, int numChapterLast, int numChapterFirst, bool downloadAll)
        {
            DowloadAll = downloadAll;
            NameManga = nameManga;
            NumTom = numTom;
            NumChapterLast = numChapterLast;
            NumChapterFirst = numChapterFirst;
        }
        public bool DowloadAll { get; set; }
        public string BaseUrl { get; set; } = "http://mintmanga.com";
        public string Prefix { get; set; } = "{num_tom}/{num_chapter}";
        public string NameManga { get; set; }
        public int NumTom { get; set; }
        public int NumChapterLast { get; set; }
        public int NumChapterFirst { get; set; }
    }
}
