using System.Collections.Generic;
using System.Threading.Tasks;
using GitStalker.Models;

namespace GitStalker.Services
{
    public interface IGitUserFetcher
    {
        Task<List<GitUser>> GetUsersFromNameAsync(string name);
    }
}