﻿using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;
using TodoAzure;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;

namespace WinPhone81
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : IAuthenticate
	{
		MobileServiceUser user;

		public MainPage ()
		{
			this.InitializeComponent ();
			this.NavigationCacheMode = NavigationCacheMode.Required;
			TodoAzure.App.Init (this);
			LoadApplication (new TodoAzure.App ());
		}

		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.
		/// This parameter is typically used to configure the page.</param>
		protected override void OnNavigatedTo (NavigationEventArgs e)
		{
			// TODO: Prepare page for display here.

			// TODO: If your application contains multiple pages, ensure that you are
			// handling the hardware Back button by registering for the
			// Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
			// If you are using the NavigationHelper provided by some templates,
			// this event is handled for you.
		}

		public async Task<bool> AuthenticateAsync ()
		{
			bool success = false;

			try {
				if (user == null) {
					user = await TodoItemManager.DefaultManager.CurrentClient.LoginAsync (MobileServiceAuthenticationProvider.Google);
					if (user != null) {
						var dialog = new MessageDialog (string.Format ("You are now logged in - {0}", user.UserId), "Authentication");
						await dialog.ShowAsync ();
					}
				}
				success = true;
			} catch (Exception ex) {
				var dialog = new MessageDialog (ex.Message, "Authentication Failed");
				await dialog.ShowAsync ();
			}
			return success;
		}

		public async Task<bool> LogoutAsync ()
		{
			bool success = false;
			try {
				if (user != null) {
					await TodoItemManager.DefaultManager.CurrentClient.LogoutAsync ();
					var dialog = new MessageDialog (string.Format ("You are now logged out - {0}", user.UserId), "Logout");
					await dialog.ShowAsync ();
				}

				user = null;
				success = true;
			} catch (Exception ex) {
				var dialog = new MessageDialog (ex.Message, "Logout failed");
				await dialog.ShowAsync ();
			}
			return success;
		}
	}
}
