namespace SimpleFeed.Data.Configuration
{
    using System;

    public interface IPersistenceConfiguration
    {
        string[] ImageFiletypes { get; set; }
        string ImageStoragePath { get; set; }
        string DefaultConnection { get; set; }
        string ContentRootPath { get; set; }

        string GetPathForUserContent(Guid userId);
    }
}
