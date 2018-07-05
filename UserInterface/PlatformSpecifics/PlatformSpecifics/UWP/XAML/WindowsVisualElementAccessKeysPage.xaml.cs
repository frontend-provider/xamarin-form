﻿using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatformSpecifics
{
	public partial class WindowsVisualElementAccessKeysPage : TabbedPage
	{
        ICommand _returnToPlatformSpecificsPage;

        public WindowsVisualElementAccessKeysPage (ICommand restore)
		{
			InitializeComponent ();
            _returnToPlatformSpecificsPage = restore;
		}

        async void OnButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            await DisplayAlert("Button clicked", $"Clicked {button?.Text}", "OK");
        }

        void OnReturnButtonClicked(object sender, EventArgs e)
        {
            _returnToPlatformSpecificsPage.Execute(null);
        }
    }
}
