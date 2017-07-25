using System;
using System.Collections.Generic;
using System.Linq;

namespace Readmanga.Core.Readmanga
{
    class RmParser : IParser<string[]>
    {
        public string[] Parse(AngleSharp.Dom.Html.IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("script").Where(item => item.OuterHtml.Contains("var transl_next_page='Следующая страница'"));
            foreach (var item in items)
            {
                string[] split = item.InnerHtml.Split(new Char[] { '[' });
                for(int i = 3; i < split.Length; i++)
                {
                    string[] spl = split[i].Split(new Char[] { ',' });
                    foreach (var s in spl)
                    {
                        list.Add(s.Trim(new Char[] { '"', '\'' }));
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return list.ToArray();
            }
        }
    }
}