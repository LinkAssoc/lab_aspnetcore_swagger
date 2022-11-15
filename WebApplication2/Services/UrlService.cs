using HtmlAgilityPack;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class UrlService : IUrlService
    {
        public async Task<UrlResponse> GetUrls(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(url).AbsoluteUri);
            string responseBody = await response.Content.ReadAsStringAsync();
            HtmlDocument htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(responseBody);
            List<string> hrefTags = new List<string>();

            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                hrefTags.Add(att.Value);
            }

            return new UrlResponse(hrefTags.ToArray(), hrefTags.Count);
        }
    }
}
