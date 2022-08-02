using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace OneDrivePublicAccess
{
    public class UrlShorteningManager
    {
        private readonly string _urlShorteningBase;
        private readonly HttpClient _client;

        public UrlShorteningManager(HttpClient httpClient)
        {
            _urlShorteningBase = @"https://kurzelinks.de/";

            _client = httpClient;
        }

        public async Task<string> GetLongUrlFromShort(string pin)
        {
            pin = $"{pin}+";
            var url = Path.Combine(_urlShorteningBase, pin);

            var oneDriveUrl = string.Empty;

            Console.WriteLine($"{url} is called");
            _client.BaseAddress = new Uri(url);
            FlurlClient httpFlurlClient = new FlurlClient(_client);
            var html = await httpFlurlClient.Request().GetStringAsync();
            
            HtmlParser parser = new HtmlParser();
            IHtmlDocument doc = parser.ParseDocument(html);
           
            var element = doc.QuerySelector("#contentdiv > .showtarget > a");

            if(element != null)
            {
                oneDriveUrl = element.TextContent.Replace("\n", string.Empty);
            }

            return oneDriveUrl;
        }
    }
}