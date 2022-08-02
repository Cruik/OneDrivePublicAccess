using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Flurl.Http;
using System.Threading.Tasks;
using OneDrivePublicAccess.Model;
using Directory = System.IO.Directory;
using File = System.IO.File;
using Root = OneDrivePublicAccess.Model.Root;

namespace OneDrivePublicAccess
{
    public class OneDriveConnector
    {
        private readonly string _externalStoragePath;

        public OneDriveConnector(string storagePath)
        {
            _externalStoragePath = storagePath;
        }

        public List<Child> GetDriveItems(string sharedLink)
        {
            var url = GetDownloadUrl(sharedLink);

            var root = GetRootObject(url);

            var downloadLinks = GetOneDriveInformation(root);

            return downloadLinks;
        }

        public string GetDownloadUrl(string sharingUrl)
        {
            string base64Value = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(sharingUrl));
            string encodedUrl = "u!" + base64Value.TrimEnd('=').Replace('/', '_').Replace('+', '-');
            string apiUrl = @"https://api.onedrive.com/v1.0/shares";

            var url = Path.Combine(apiUrl, encodedUrl, "driveItem?$expand=children");

            return url;
        }

        public Model.Root GetRootObject(string onedriveUrl)
        {
            Model.Root rootObject = onedriveUrl.GetJsonAsync<Model.Root>().GetAwaiter().GetResult();

            return rootObject;
        }

        public List<Child> GetOneDriveInformation(Root rootObject)
        {
            var downloadLinks = new List<Child>();

            if (rootObject.ChildrenOdataCount > 0)
            {
                foreach (var child in rootObject.Children)
                {
                    bool isFile = CheckIfChildIsFile(child);

                    if (isFile)
                    {
                        downloadLinks.Add(child);
                    }
                    else if (child.Folder?.ChildCount > 0)
                    {
                        var downloadUrl = GetDownloadUrl(child.WebUrl);
                        var root = GetRootObject(downloadUrl);

                        downloadLinks.AddRange(GetOneDriveInformation(root));
                    }
                }
            }

            return downloadLinks;
        }

        public async Task DownloadFile(Child child)
        {
            var stream = await child.ContentDownloadUrl.GetStreamAsync();
         
            var directoryName = _externalStoragePath;
            try
            {
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }

                var fileName = Path.Combine(directoryName, child.Name);

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (var fs = File.Create(fileName))
                {
                    stream.CopyTo(fs);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, ex.Message);
            }
        }

        private bool CheckIfChildIsFile(Child child)
        {
            bool isFile = child.File != null;

            return true;
        }

        public void CleanDownloadDestination()
        {
            //todo clean directory before download starts
            //check if App is in use!!!!!
        }
    }
}