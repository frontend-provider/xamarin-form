﻿using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithListview
{
	public class CustomCellPage : ContentPage
	{
		public CustomCellPage ()
		{
			var listView = new ListView ();

			listView.ItemsSource = new [] { "a", "b", "c" };
			listView.ItemTemplate = new DataTemplate(typeof(CustomCell));

			listView.ItemTapped += (sender, e) => {
				if (e == null) return; // has been set to null, do not 'process' tapped event
				DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
				((ListView)sender).SelectedItem = null; // de-select the row
			};

			Padding = new Thickness (0,20,0,0);
			Content = listView;
		}
	}
}

