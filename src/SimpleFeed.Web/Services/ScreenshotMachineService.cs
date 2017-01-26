namespace SimpleFeed.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using _Configuration;

    public class ScreenshotMachineService : IWebScreenshotService
    {
        private readonly IOptions<ExternalServices> _externalServices;

        public ScreenshotMachineService(IOptions<ExternalServices> externalServices)
        {
            if (externalServices == null) throw new ArgumentNullException(nameof(externalServices));
            _externalServices = externalServices;
        }

        public async Task<HttpResponseMessage> GetScreenshotFor(string url)
        {
            var serviceUrl = $"http://api.screenshotmachine.com" +
                             $"?key={_externalServices.Value.ScreenshotMachine}&size=X&format=JPG" +
                             $"&timeout={_externalServices.Value.ScreenshotMachineTimeout}&url={url}";
            return await new HttpClient().GetAsync(serviceUrl);
        }
    }
}
