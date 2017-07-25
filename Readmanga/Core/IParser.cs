using AngleSharp.Dom.Html;

namespace Readmanga.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
