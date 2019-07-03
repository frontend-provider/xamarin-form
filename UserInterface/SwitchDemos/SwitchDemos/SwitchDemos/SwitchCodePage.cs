﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SwitchDemos
{
    public class SwitchCodePage : ContentPage
    {
        Label switchStateLabel;

        public SwitchCodePage()
        {
            Title = "Switch Code Demo";

            switchStateLabel = new Label
            {
                Text = "Switch state is OFF",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Switch switchControl = new Switch
            {
                IsToggled = false,
                OnColor = Color.Green,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            switchControl.Toggled += SwitchControl_Toggled;

            Content = new StackLayout
            {
                Children =
                {
                    switchStateLabel,
                    switchControl
                }
            };
        }

        private void SwitchControl_Toggled(object sender, ToggledEventArgs e)
        {
            var stateName = e.Value ? "ON" : "OFF";
            switchStateLabel.Text = $"The switch is {stateName}";
        }
    }
}
