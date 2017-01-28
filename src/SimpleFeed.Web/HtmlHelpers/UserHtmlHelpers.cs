namespace SimpleFeed.HtmlHelpers
{
    using Core;
    using Core.FeedEntries.Base;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public static class UserHtmlHelpers
    {
        public static IHtmlContent ActivityPartialFor(this IHtmlHelper helper, ModelBase model)
        {
            return helper.Partial($"_{model.GetType().Name}Partial", model, null);
        }
    }
}
