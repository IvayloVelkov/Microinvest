using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android;
using Android.Support.V4.App;

namespace App2.Droid
{
    [Activity(Label = "App2", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected async override  void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            await GetPermissionsAsync();  
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        const int RequestLocationId = 0;

        readonly string[] PermissionsGroupLocation =
           {
                 Manifest.Permission.Camera,
                 Manifest.Permission.ReadExternalStorage,
                 Manifest.Permission.WriteExternalStorage

           };

        async Task GetPermissionsAsync()
        {
            await Task.Run(() =>
            {
                const string permission1 = Manifest.Permission.Camera;
                const string permission2 = Manifest.Permission.ReadExternalStorage;
                const string permission3 = Manifest.Permission.WriteExternalStorage;



                if (ActivityCompat.CheckSelfPermission(this, permission1) == (int)Permission.Granted &&
                    ActivityCompat.CheckSelfPermission(this, permission2) == (int)Permission.Granted  &&
                    ActivityCompat.CheckSelfPermission(this, permission3) == (int)Permission.Granted)

                {
                    return;
                }

                RequestPermissions(PermissionsGroupLocation, RequestLocationId);
            });
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {

            switch (requestCode)
            {
                case RequestLocationId:
                    {
                        if (grantResults[0] == (int)Permission.Granted && grantResults[1] == (int)Permission.Granted &&
                            grantResults[2] == (int)Permission.Granted)
                        {
                            Toast.MakeText(this, "Special permissions granted", ToastLength.Short).Show();
                        }
                        else
                        {
                            Toast.MakeText(this, "Special permissions denied", ToastLength.Short).Show();
                            var activity = (Activity)this;
                            activity.FinishAffinity();
                        }
                    }
                    break;
            }
        }
    }
}