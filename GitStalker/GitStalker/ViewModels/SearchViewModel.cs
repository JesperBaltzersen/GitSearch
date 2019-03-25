using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GitStalker.Models;
using GitStalker.Services;
using MvvmHelpers;
using Xamarin.Forms;

namespace GitStalker.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly GitUserFetcher _gitUserFetcher;

        public ObservableRangeCollection<GitUser> GitUsers { get; set; }
        public GitUser CurrentUser { get; set; }

        public SearchViewModel(GitUserFetcher gitUserFetcher)
        {
            GitUsers = new ObservableRangeCollection<GitUser>();
            _gitUserFetcher = gitUserFetcher;
            SearchGithubUserCommand = new Command<string>(
                async (x) => await SearchGithubUser(x), 
                (_) => !IsBusy);

            //GitUsers.CollectionChanged += (sender, e) => 
            //{
            //    Debug.WriteLine($"Item {e.Action}"); 
            //};


        }

        public Command<string> SearchGithubUserCommand { get;}
        async Task SearchGithubUser(string name)
        {
            IsBusy = true;
            var users = await _gitUserFetcher.GetUsersFromNameAsync(name);
            GitUsers.AddRange(users);
            IsBusy = false;

        }   

        void OnUserSelected(GitUser sender, SelectedItemChangedEventArgs e)
        {
            var chosenUser = e.SelectedItem as GitUser;
            if (chosenUser != null)
            {
                CurrentUser = chosenUser;
            }
        }
    }
}
