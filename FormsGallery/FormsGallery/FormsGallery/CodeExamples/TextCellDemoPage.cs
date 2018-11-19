﻿using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class TextCellDemoPage : ContentPage
    {
        public TextCellDemoPage()
        {
            Label header = new Label
            {
                Text = "TextCell",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        new TextCell
                        {
                            Text = "This is a TextCell",
                            Detail = "This is some detail text",
                        }
                    }
                }
            };

            // Build the page.
            Title = "TextCell Demo";
            Padding = new Thickness(10, 0);
            Content = new StackLayout
            {
                Children = 
                {
                    header,
                    tableView
                }
            };
        }
    }
}
