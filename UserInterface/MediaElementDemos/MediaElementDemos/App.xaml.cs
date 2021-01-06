﻿using MediaElementDemos.Helpers;
using Xamarin.Forms;

namespace MediaElementDemos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override async void OnStart()
        {
            await FileAccess.CopyVideoIfNotExists("XamarinForms101UsingEmbeddedImages.mp4");
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
