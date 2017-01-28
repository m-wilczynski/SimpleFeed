namespace SimpleFeed.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using _Configuration;

    public class ScreenshotLayerService : IWebScreenshotService
    {
        private readonly IOptions<ExternalServices> _externalServices;

        public ScreenshotLayerService(IOptions<ExternalServices> externalServices)
        {
            if (externalServices == null) throw new ArgumentNullException(nameof(externalServices));
            _externalServices = externalServices;
        }

        public async Task<HttpResponseMessage> GetScreenshotFor(string url)
        {
            var serviceUrl =
                "http://api.screenshotlayer.com/api/capture?" +
                $"access_key={_externalServices.Value.ScreenshotLayer}&url={url}&force=1&viewport=1024x768&width=1024";
            return await new HttpClient().GetAsync(serviceUrl);
        }
    }
}
