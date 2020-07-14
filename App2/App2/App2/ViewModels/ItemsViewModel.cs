using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using App2.Models;
using App2.Views;
using System.Windows.Input;

namespace App2.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private string username;
        private ICommand loginCommand;

        public INavigation Navigation { get; internal set; }

        public string UserName 
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged("UserName");
            } 
        }

        public ICommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new Command(Login));
            }
        }

        public ItemsViewModel()
        {
        }

        private async void Login(object obj)
        {
            if (!string.IsNullOrEmpty(UserName))
            {
                await Navigation.PushAsync(new AboutPage());
            }
            else
            {
                string message = "Wrong Username";
                switch (Device.RuntimePlatform)
                {
                    case Device.UWP:
                        await Application.Current.MainPage.DisplayAlert("Внимание", message, "ОК");
                        break;
                    case Device.Android:
                        DependencyService.Get<IToastMessage>().ShowMessage(message);
                        break;
                }
               
            }   
        }

    }
}