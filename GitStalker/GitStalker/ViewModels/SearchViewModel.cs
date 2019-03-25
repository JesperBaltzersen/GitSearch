using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GitStalker.Models;
using GitStalker.Services;
using MvvmHelpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GitStalker.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly GitUserFetcher _gitUserFetcher;
        private readonly string GithubUserBaseUrl = "https://github.com/";

        public ObservableRangeCollection<GitUser> GitUsers { get; set; }
        public GitUser CurrentUser { get; set; }

        public SearchViewModel(GitUserFetcher gitUserFetcher)
        {
            GitUsers = new ObservableRangeCollection<GitUser>();
            _gitUserFetcher = gitUserFetcher;

            SearchGithubUserCommand = new Command<string>(
                async (x) => await SearchGithubUser(x), 
                (_) => !IsBusy);

            VisitOnGithubCommand = new Command<string>(
                async (_) => await VisitOnGithub());


        }

        public Command<string> SearchGithubUserCommand { get;}
        async Task SearchGithubUser(string name)
        {
            IsBusy = true;
            var users = await _gitUserFetcher.GetUsersFromNameAsync(name);
            GitUsers.ReplaceRange(users);
            ShowGrid = false;
            IsBusy = false;
            ShowList = true;
        }


        public Command<string> VisitOnGithubCommand { get; }
        async Task VisitOnGithub()
        {
            await Browser.OpenAsync(GithubUserBaseUrl + SelectedUser.login, BrowserLaunchMode.SystemPreferred);
        }

        GitUser _selectedtUser;
        public GitUser SelectedUser 
        {
            get
            {
                return _selectedtUser;
            }
            set
            {
                SetProperty(ref _selectedtUser, value);
                Username = value?.login;
                ImageSource = value?.avatar_url;
               
                Score = "Score : " + Convert.ToInt32(value?.score).ToString();
                if (_selectedtUser != null)
                {
                    ShowGrid = true;
                }
            }
        }

        string _username;
        public string Username 
        { 
            get => _username ?? ""; 
            set => SetProperty(ref _username, value); 
        }

        string _imageSource;
        public string ImageSource
        {
            get => _imageSource ?? "";
            set => SetProperty(ref _imageSource, value);
        }

        string _score;
        public string Score
        {
            get => _score ?? "";
            set => SetProperty(ref _score, value);
        }

        bool _showGrid;
        public bool ShowGrid
        {
            get => _showGrid;
            set => SetProperty(ref _showGrid, value);
        }

        bool _showList;
        public bool ShowList
        {
            get => _showList;
            set => SetProperty(ref _showList, value);
        }
        //public string Username
        //{
        //    get => SelectedUser.login;
        //    set => Username = value;
        //}

        //void OnUserSelected(GitUser sender, SelectedItemChangedEventArgs e)
        //{
        //    var chosenUser = e.SelectedItem as GitUser;
        //    if (chosenUser != null)
        //    {
        //        CurrentUser = chosenUser;
        //    }
        //}
    }
}
