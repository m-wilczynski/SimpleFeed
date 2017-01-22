namespace SimpleFeed.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IWebScreenshotService
    {
        Task<HttpResponseMessage> GetScreenshotFor(string url);
    }
}
