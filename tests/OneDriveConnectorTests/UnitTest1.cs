using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using OneDrivePublicAccess;

namespace OneDriveConnectorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var storagePath = Path.GetTempPath();
            var kurzeLinksTag = @"123456";

            
            var httpClient = new HttpClient();

            //der HttpClient kann hier dann über den DependencyService reingereicht werden.
            var urlManager = new UrlShorteningManager(httpClient);

            string oneDriveShareLink = urlManager.GetLongUrlFromShort(kurzeLinksTag).GetAwaiter().GetResult();

            var oneDriveConnector = new OneDriveConnector(storagePath);

            var items = oneDriveConnector.GetDriveItems(oneDriveShareLink);

            foreach (var item in items)
            {
                oneDriveConnector.DownloadFile(item).GetAwaiter().GetResult();
            }
        }
    }
}