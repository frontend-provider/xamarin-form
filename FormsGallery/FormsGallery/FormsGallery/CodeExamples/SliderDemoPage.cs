﻿using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class SliderDemoPage : ContentPage
    {
        Label label;

        public SliderDemoPage()
        {
            Label header = new Label
            {
                Text = "Slider",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Slider slider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(10, 0)
            };
            slider.ValueChanged += OnSliderValueChanged;

            label = new Label
            {
                Text = "Slider value is 0",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Build the page.
            Title = "Slider Demo";
            Content = new StackLayout
            {
                Children = 
                {
                    header,
                    slider,
                    label
                }
            };
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            label.Text = String.Format("Slider value is {0:F1}", e.NewValue);
        }
    }
}
