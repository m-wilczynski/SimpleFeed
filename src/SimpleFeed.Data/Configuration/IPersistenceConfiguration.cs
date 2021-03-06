﻿namespace SimpleFeed.Data.Configuration
{
    using System;
    using Core.FeedEntries;

    public interface IPersistenceConfiguration
    {
        string[] ImageFiletypes { get; set; }
        string ImageStoragePath { get; set; }
        string DefaultConnection { get; set; }
        string ContentRootPath { get; set; }

        string GetAbsolutePathForUserContent(Guid userId);
        string GetRelativePathForUserContent(Guid userId, RelativePathRoot root = RelativePathRoot.WebRoot);
        string GetRelativePathForUrlSnapshot(ExternalLinkFeedEntry feedEntry, RelativePathRoot root = RelativePathRoot.WebRoot);
    }

    public enum RelativePathRoot
    {
        WebRoot,
        ContentRoot
    }
}
