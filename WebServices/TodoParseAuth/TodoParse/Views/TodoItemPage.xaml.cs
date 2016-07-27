﻿using System;
using Xamarin.Forms;

namespace TodoParse
{
	public partial class TodoItemPage : ContentPage
	{
		public TodoItemPage ()
		{
			InitializeComponent ();
		}

		async void OnSaveActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.SaveTaskAsync(todoItem);
			Navigation.PopAsync();
		}

		async void OnDeleteActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.DeleteTaskAsync(todoItem);
			Navigation.PopAsync();
		}

		void OnCancelActivated (object sender, EventArgs e)
		{
			Navigation.PopAsync();
		}

		void OnSpeakActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			App.Speech.Speak(todoItem.Name + " " + todoItem.Notes);
		}
	}
}
	