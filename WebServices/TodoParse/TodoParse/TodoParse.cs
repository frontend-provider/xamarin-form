﻿using System;
using Xamarin.Forms;

namespace TodoParse
{
	public class App : Application
	{
		public static TodoItemManager TodoManager { get; set; }

		public static ITextToSpeech Speech { get; set; }

		public App ()
		{
			MainPage = new NavigationPage (new TodoListPage ());	
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
