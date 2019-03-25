using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestDL.Data;
using TestDL.Pages;
using Xamarin.Forms;

namespace TestDL
{
    public partial class MainPage : ContentPage
    {
        public string GitUser { get; set; }
        public MainPage()
        {
            InitializeComponent();
            //setup github connection
            var client = new HttpClient();
            var baseUrl = "https://api.github.com/search/users?q=";
            var searchName = "Jesper";

            var user = GetUser(baseUrl + searchName);
        }

        private string GetUser(string searchString)
        {
            var result = "";
            Task.Run(async () =>
            {
                try
                {
                    var client = new HttpClient();
                    result = await client.GetStringAsync(searchString);
                    var daContent = JsonConvert.DeserializeObject<RootObject>(result);
                    var res2 = await client.GetAsync(searchString);
                    Device.BeginInvokeOnMainThread(() => {
                        gitusers.Text = result.Substring(25, 95);
                    });
                    //Console.WriteLine(res2.RequestMessage);
                    //var users = new GitUsersString();
                    //Device.BeginInvokeOnMainThread(() => {
                    //    gitusers.Text = users.root.items.First().ToString();
                    //});
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            });
            return result;
        }

        async void onUserSearchPageClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync( new UserSearchPage());
        }


        async void onListTestClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ListTestPage());
        }

        async void onTestMVVMClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new TestMVVM2Page());
        }


    }

    public class Item
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
        public double score { get; set; }
    }

    public class RootObject
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<Item> items { get; set; }
    }
}
