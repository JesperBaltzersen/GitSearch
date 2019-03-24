using System;
using System.Threading.Tasks;

namespace GitStalker.Services
{
    public class DownloadService : IDownloadService
    {
        public DownloadService()
        {
        }

        public async Task<string> GetStringFromUrl(string url)
        {
            throw new NotImplementedException();
        }
    }
}
