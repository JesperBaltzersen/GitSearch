using System.Threading.Tasks;

namespace GitStalker.Services
{
    public interface IDownloadService
    {
        Task<string> GetStringFromUrl(string url);
    }
}