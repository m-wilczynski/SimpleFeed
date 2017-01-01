namespace SimpleFeed._Configuration
{
    using System;
    using System.IO;
    using Data.Configuration;

    public class PersistenceConfiguration : IPersistenceConfiguration
    {
        public string[] ImageFiletypes { get; set; }
        public string ImageStoragePath { get; set; }
        public string DefaultConnection { get; set; }
        public string ContentRootPath { get; set; }

        public string GetAbsolutePathForUserContent(Guid userId)
        {
            return Path.Combine(ContentRootPath, "wwwroot", ImageStoragePath, userId.ToString().Replace("-", ""), DateTime.Now.Year.ToString())
                .Replace(@"\", "/");
        }

        public string GetRelativePathForUserContent(Guid userId, RelativePathRoot root = RelativePathRoot.WebRoot)
        {
            return Path.Combine(root != RelativePathRoot.WebRoot ? "wwwroot" : "", ImageStoragePath, userId.ToString().Replace("-", ""), DateTime.Now.Year.ToString())
                .Replace(@"\", "/");
        }
    }
}
