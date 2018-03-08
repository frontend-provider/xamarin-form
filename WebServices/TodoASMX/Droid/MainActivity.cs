﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace TodoASMX.Droid
{
    [Activity(Label = "TodoASMX.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Instance = this;
            global::Xamarin.Forms.Forms.Init(this, bundle);

            App.TodoManager = new TodoItemManager(new SoapService());
            App.Speech = new Speech();
            LoadApplication(new App());
        }
    }
}
