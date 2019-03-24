using GitStalker.Models;
using GitStalker.Services;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture()]
    public class TestGithubDownload
    {
        [Test()]
        public void GetUsersFromName_Returns_ResponseObjectIncludingActualUser()
        {
            IDownloadService downloadService = new FakeDownloadService();
            GitUserFetcher gitUserFetcher = new GitUserFetcher(downloadService);

            GitUser expectedGitUser = new GitUser();
            expectedGitUser.id = 1334;
            expectedGitUser.login = "jesper";

            var resultUsers = gitUserFetcher.GetUsersFromNameAsync("jesper").Result;
            var resultUser = resultUsers.Find((GitUser user) => user.login == "jesper");

            Assert.AreEqual(0, expectedGitUser.CompareTo(resultUser));
        }
    }

    internal class FakeDownloadService : IDownloadService
    {
        public async Task<string> GetStringFromUrl(string url)
        {
            string json;
            var assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("Tests.GitUsers.json");
            using (StreamReader r = new StreamReader(stream))
            {
                json = await r.ReadToEndAsync();
            }
            return json; 
        }
    }
}



