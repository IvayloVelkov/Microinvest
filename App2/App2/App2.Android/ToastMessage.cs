using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App2.Models;

[assembly: Xamarin.Forms.Dependency(typeof(App2.Droid.ToastMessage))]
namespace App2.Droid
{
    public class ToastMessage : IToastMessage
    {
        public void ShowMessage(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}