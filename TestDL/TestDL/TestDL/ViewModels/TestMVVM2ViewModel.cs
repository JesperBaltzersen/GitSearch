using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestDL.ViewModels
{
    internal class TestMVVM2ViewModel : INotifyPropertyChanged
    {
        private string _username = "hello";
        private string _searchName;
        private bool _didChange;
        private bool _isBusy;

        public TestMVVM2ViewModel()
        {
            SearchNameCommand = new Command(async () => await SearchNameM(), () => !IsBusy);
        }

        async Task SearchNameM()
        {
            SearchName = "searched";
            DidChange = true;
            IsBusy = true;
            await Task.Delay(4000);
            IsBusy = false;
            OnPropertyChanged(nameof(DidChange));

        }

        public string Username 
        {
            get { return _username;} 
            set { _username = value; }
        }

        public string SearchName 
        {
            get { return _searchName; } 
            set 
            { 
                _searchName = value;
                OnPropertyChanged();
                Username = _searchName;
                //IsBusy = !IsBusy;
                OnPropertyChanged(nameof(Username));
            }
        }

        public bool DidChange
        {
            get { return _didChange; }
            set { _didChange = value; }
        }

        public Command SearchNameCommand { get; }
        public bool IsBusy 
        { 
            get { return _isBusy; } 
            set 
            {
                _isBusy = value;

                SearchNameCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}