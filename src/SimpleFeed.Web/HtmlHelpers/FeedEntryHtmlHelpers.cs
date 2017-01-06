namespace SimpleFeed.HtmlHelpers
{
    using Core.FeedEntries.Base;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public static class FeedEntryHtmlHelpers
    {
        public static IHtmlContent FeedEntryPartialFor(this IHtmlHelper helper, FeedEntryBase feedEntry)
        {
            return helper.Partial($"_{feedEntry.GetType().Name}Partial", feedEntry, null);
        }
    }
}
