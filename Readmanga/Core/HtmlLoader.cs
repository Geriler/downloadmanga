using Readmanga.Properties;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Readmanga.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;
        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}/{settings.NameManga}/vol{settings.Prefix}";
        }
        public async Task<string> GetSourceByPageId (int tom, int chapter)
        {
            var currentUrl = url.Replace("{num_tom}", tom.ToString());
            currentUrl = currentUrl.Replace("{num_chapter}", chapter.ToString());
            var response = await client.GetAsync(currentUrl);
            string source = null;
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }
            return source;
        }
    }
}