using System;

namespace SimpleFeed.Core.FeedEntries
{
    using Base;
    using Exceptions;

    public class ExternalLinkFeedEntry : FeedEntryBase
    {
        private Uri _linkAddress;

        public ExternalLinkFeedEntry(Uri linkAddress, string title, Guid creatorId, Guid? id = default(Guid?)) : base(title, creatorId, id)
        {
            LinkAddress = linkAddress;
        }

        public Uri LinkAddress
        {
            get { return _linkAddress; }
            set
            {
                if (!ValidateLinkUri(value)) throw new InvalidUriException(value, "Invalid link address");
                _linkAddress = value;
            }
        }

        public static bool ValidateLinkUri(Uri link)
        {
            return link != null && link.IsAbsoluteUri && !link.IsFile;
        }
    }
}
