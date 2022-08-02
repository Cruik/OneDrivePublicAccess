using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OneDrivePublicAccess.Model
{
    public class Root
    {
        [JsonProperty("@odata.context")] public string OdataContext { get; set; }

        [JsonProperty("createdBy")] public CreatedBy CreatedBy { get; set; }

        [JsonProperty("createdDateTime")] public DateTime CreatedDateTime { get; set; }

        [JsonProperty("cTag")] public string CTag { get; set; }

        [JsonProperty("eTag")] public string ETag { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("lastModifiedBy")] public LastModifiedBy LastModifiedBy { get; set; }

        [JsonProperty("lastModifiedDateTime")] public DateTime LastModifiedDateTime { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("parentReference")] public ParentReference ParentReference { get; set; }

        [JsonProperty("size")] public int Size { get; set; }

        [JsonProperty("webUrl")] public string WebUrl { get; set; }

        [JsonProperty("fileSystemInfo")] public FileSystemInfo FileSystemInfo { get; set; }

        [JsonProperty("folder")] public Folder Folder { get; set; }

        [JsonProperty("reactions")] public Reactions Reactions { get; set; }

        [JsonProperty("shared")] public Shared Shared { get; set; }

        [JsonProperty("children@odata.context")]
        public string ChildrenOdataContext { get; set; }

        [JsonProperty("children@odata.count")] public int ChildrenOdataCount { get; set; }

        [JsonProperty("children")] public List<Child> Children { get; set; }
    }
}