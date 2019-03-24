using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitStalker.Models;
using Newtonsoft.Json;

namespace GitStalker.Services
{
    public class GitUserFetcher : IGitUserFetcher
    {
        private IDownloadService _downloadService;
        private readonly string BASEURL = "https://api.github.com/users/";

        public GitUserFetcher(IDownloadService downloadService)
        {
            _downloadService = downloadService;
        }

        public async Task<List<GitUser>> GetUsersFromNameAsync(string name)
        {
            var usersResponseString = await _downloadService.GetStringFromUrl(BASEURL + name);
            var usersResponseObject = JsonConvert.DeserializeObject<GitUserSearchResponse>(usersResponseString);
            return usersResponseObject.GitUsers;
        }


        //root.items.ForEach((obj) => users.Add(new Item { login = obj.login }));
    }
}
