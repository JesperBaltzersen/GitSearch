using System;
using System.Collections.Generic;
using TestDL.ViewModels;

using Xamarin.Forms;

namespace TestDL.Pages
{
    public partial class TestMVVM2Page : ContentPage
    {
        public TestMVVM2Page()
        {
            InitializeComponent();
            BindingContext = new TestMVVM2ViewModel();
        }
    }
}
