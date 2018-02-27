﻿using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class FrameDemoPage : ContentPage
    {
        public FrameDemoPage()
        {
            Label header = new Label
            {
                Text = "Frame",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Frame frame = new Frame
            {
                OutlineColor = Color.Accent,
                HasShadow = true,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "I've been framed!"
                }
            };

            // Build the page.
            Title = "Frame Demo";
            Content = new StackLayout
            {
                Children = 
                {
                    header,
                    frame
                }
            };
        }
    }
}
