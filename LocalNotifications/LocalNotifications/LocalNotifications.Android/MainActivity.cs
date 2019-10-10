﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;

namespace LocalNotifications.Droid
{
    [Activity(Label = "LocalNotifications",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            CreateNotificationFromIntent(Intent);
        }

        protected override void OnNewIntent(Intent intent)
        {
            CreateNotificationFromIntent(intent);
        }

        private void CreateNotificationFromIntent(Intent intent)
        {
            if(intent?.Extras != null)
            {
                var title = intent.Extras.GetString(AndroidNotificationManager.TitleKey);
                var message = intent.Extras.GetString(AndroidNotificationManager.MessageKey);

                DependencyService.Get<INotificationManager>().ReceiveNotification(title, message);
            }
        }
    }
}