using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using TestDL.Data;
using Xamarin.Forms;

namespace TestDL
{
    public partial class ListTestPage : ContentPage
    {
        ObservableCollection<Item> Users = new ObservableCollection<Item>();
        public ListTestPage()
        {
            InitializeComponent();

            Task.Run(async () =>
            {
                await GitUsersString.SetGitUsersStringAsync();
                GitUsersString.users.ForEach((Item obj) => Users.Add(obj));

                gitters.ItemsSource = Users;

            });

        }
    }
}
