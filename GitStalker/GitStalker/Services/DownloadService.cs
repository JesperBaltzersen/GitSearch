using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitStalker.Services
{
    public class DownloadService : IDownloadService
    {
        private HttpClient httpClient;

        public DownloadService()
        {
            httpClient = new HttpClient();
        }

        public async Task<string> GetStringFromUrl(string url)
        {
            return await GetStringFromUrlWithRetry(url);
            
        }

        async Task<string> GetStringFromUrlWithRetry(string url, bool isFirstTry = true)
        {
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else if (!response.IsSuccessStatusCode && isFirstTry == true)
            {
                await Task.Delay(1000);
                await GetStringFromUrlWithRetry(url, false);
            }

            return await Task.FromResult<string>("Failed to retrieve users");

        }
    }
}
