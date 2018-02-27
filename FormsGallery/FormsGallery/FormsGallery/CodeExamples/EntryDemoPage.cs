﻿using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class EntryDemoPage : ContentPage
    {
        public EntryDemoPage()
        {
            Label header = new Label
            {
                Text = "Entry",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            // Build the page.
            Title = "Entry Demo";
            Padding = new Thickness(10, 0);
            Content = new StackLayout
            {
                Children = 
                {
                    header,

                    new Entry
                    {
                        Keyboard = Keyboard.Email,
                        Placeholder = "Enter email address",
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    },

                    new Entry
                    {
                        Keyboard = Keyboard.Text,
                        Placeholder = "Enter password",
                        IsPassword = true,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    },

                    new Entry
                    {
                        Keyboard = Keyboard.Telephone,
                        Placeholder = "Enter phone number",
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}
