namespace Readmanga.Core
{
    interface IParserSettings
    {
        bool DowloadAll { get; set; }
        string BaseUrl { get; set; }
        string Prefix { get; set; }
        string NameManga { get; set; }
        int NumTom { get; set; }
        int NumChapterLast { get; set; }
        int NumChapterFirst { get; set; }
    }
}