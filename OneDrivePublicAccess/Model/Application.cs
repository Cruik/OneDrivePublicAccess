using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OneDrivePublicAccess.Model
{
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Application
    {
        [JsonProperty("displayName")] public string DisplayName { get; set; }

        [JsonProperty("id")] public string Id { get; set; }
    }

    public class Child
    {
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

        [JsonProperty("@content.downloadUrl")] public string ContentDownloadUrl { get; set; }

        [JsonProperty("file")] public File File { get; set; }

        [JsonProperty("image")] public Image Image { get; set; }

        [JsonProperty("photo")] public Photo Photo { get; set; }
    }

    public class CreatedBy
    {
        [JsonProperty("application")] public Application Application { get; set; }

        [JsonProperty("user")] public User User { get; set; }
    }

    public class File
    {
        [JsonProperty("hashes")] public Hashes Hashes { get; set; }

        [JsonProperty("mimeType")] public string MimeType { get; set; }
    }

    public class FileSystemInfo
    {
        [JsonProperty("createdDateTime")] public DateTime CreatedDateTime { get; set; }

        [JsonProperty("lastModifiedDateTime")] public DateTime LastModifiedDateTime { get; set; }
    }

    public class Folder
    {
        [JsonProperty("childCount")] public int ChildCount { get; set; }

        [JsonProperty("folderView")] public FolderView FolderView { get; set; }

        [JsonProperty("folderType")] public string FolderType { get; set; }
    }

    public class FolderView
    {
        [JsonProperty("viewType")] public string ViewType { get; set; }

        [JsonProperty("sortBy")] public string SortBy { get; set; }

        [JsonProperty("sortOrder")] public string SortOrder { get; set; }
    }

    public class Hashes
    {
        [JsonProperty("quickXorHash")] public string QuickXorHash { get; set; }

        [JsonProperty("sha1Hash")] public string Sha1Hash { get; set; }

        [JsonProperty("sha256Hash")] public string Sha256Hash { get; set; }
    }

    public class Image
    {
        [JsonProperty("height")] public int Height { get; set; }

        [JsonProperty("width")] public int Width { get; set; }
    }

    public class LastModifiedBy
    {
        [JsonProperty("application")] public Application Application { get; set; }

        [JsonProperty("user")] public User User { get; set; }
    }

    public class Owner
    {
        [JsonProperty("user")] public User User { get; set; }
    }

    public class ParentReference
    {
        [JsonProperty("driveId")] public string DriveId { get; set; }

        [JsonProperty("driveType")] public string DriveType { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("path")] public string Path { get; set; }

        [JsonProperty("shareId")] public string ShareId { get; set; }
    }

    public class Photo
    {
    }

    public class Reactions
    {
        [JsonProperty("commentCount")] public int CommentCount { get; set; }
    }

    public class Shared
    {
        [JsonProperty("effectiveRoles")] public List<string> EffectiveRoles { get; set; }

        [JsonProperty("owner")] public Owner Owner { get; set; }

        [JsonProperty("scope")] public string Scope { get; set; }

        [JsonProperty("sharedDateTime")] public DateTime SharedDateTime { get; set; }
    }

    public class User
    {
        [JsonProperty("displayName")] public string DisplayName { get; set; }

        [JsonProperty("id")] public string Id { get; set; }
    }
}