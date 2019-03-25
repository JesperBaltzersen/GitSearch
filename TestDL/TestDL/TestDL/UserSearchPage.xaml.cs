using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TestDL
{
    public partial class UserSearchPage : ContentPage
    {
        public string GitUserName { get; set; }
        public UserSearchPage()
        {
            InitializeComponent();
            GitUserName = GithubUser.Text;

        }

        async void GitNameEntered(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ListTestPage());
        }
    }
}
