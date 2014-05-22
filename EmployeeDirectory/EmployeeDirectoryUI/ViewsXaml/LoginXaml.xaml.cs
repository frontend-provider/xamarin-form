﻿using System;
using Xamarin.Forms;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;

namespace EmployeeDirectoryUI.Xaml
{
	public partial class LoginXaml : ContentPage
	{
		private LoginViewModel viewModel;

		public LoginXaml ()
		{
			InitializeComponent ();
			BindingContext = new LoginViewModel (App.Service);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

		}

		private void OnLoginClicked (object sender, EventArgs e)
		{
			if (viewModel.CanLogin) {
				viewModel
				.LoginAsync (System.Threading.CancellationToken.None)
				.ContinueWith (_ => {
					App.LastUseTime = System.DateTime.UtcNow;

						Navigation.PopModalAsync ();
				});

				Navigation.PopModalAsync ();
			} else {
				DisplayAlert ("Error", viewModel.ValidationErrors, "OK", null);
			}
		}

		private void OnHelpClicked (object sender, EventArgs e)
		{
			DisplayAlert ("Help", "Enter any username and password", "OK", null);
		}
	}
}

