using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private ICommand openCommand;
        public ICommand OpenCommand => openCommand ?? (openCommand = new Command(OpenCamera));

        public AboutViewModel()
        {
        }


        private async void OpenCamera(object obj)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                DefaultCamera = CameraDevice.Rear
            });

            if (file != null)
            {
                if (file.Path != string.Empty)
                {
                   
                }
            }
        }
    }
}