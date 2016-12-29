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

        public string GetPathForUserContent(Guid userId)
        {
            return Path.Combine(ContentRootPath, ImageStoragePath, userId.ToString().Replace("-", ""), DateTime.Now.Year.ToString());
        }


    }
}
