using System;
using System.Collections.Generic;
using GitStalker.Services;
using Xamarin.Forms;

namespace GitStalker.ViewModels
{
    public partial class SearchPage : ContentPage
    {

        public SearchPage()
        {
            InitializeComponent();

            BindingContext = new SearchViewModel(new GitUserFetcher(new DownloadService()));
        }
    }
}
