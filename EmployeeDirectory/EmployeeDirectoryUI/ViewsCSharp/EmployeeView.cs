﻿using System;
using Xamarin.Forms;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;
using EmployeeDirectory.Utilities;
using System.Diagnostics;

namespace EmployeeDirectoryUI.CSharp
{
    public class EmployeeView : ContentPage
    {
        private const int IMAGE_SIZE = 150;
        private Label favoriteLabel;
        private Xamarin.Forms.Switch favoriteSwitch;
        private Image photo;

        public EmployeeView()
        {
            photo = new Image { WidthRequest = IMAGE_SIZE, HeightRequest = IMAGE_SIZE };
            photo.SetBinding(Image.SourceProperty, "DetailsPlaceholder.jpg");

            favoriteLabel = new Label();
            favoriteSwitch = new Xamarin.Forms.Switch();

            var optionsView = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { favoriteLabel, favoriteSwitch }
            };

            var headerView = new StackLayout
            {
                Padding = new Thickness(10, 20, 10, 0),
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = { photo, optionsView }
            };

            var listView = new ListView { IsGroupingEnabled = true };
            listView.ItemSelected += OnItemSelected;
            listView.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "PropertyGroups");
            listView.GroupHeaderTemplate = new DataTemplate(typeof(GroupHeaderTemplate));
            listView.ItemTemplate = new DataTemplate(typeof(DetailsItemTemplate));

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = { headerView, listView }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            favoriteSwitch.Toggled += OnFavoriteClicked;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var personInfo = (PersonViewModel)BindingContext;
            Title = personInfo.Person.Name;
            favoriteLabel.Text = personInfo.IsFavorite ? "Added to favorites" : "Not in favorites";
            favoriteSwitch.IsToggled = personInfo.IsFavorite;
            DownloadImage();
        }

        private void OnFavoriteClicked(object sender, ToggledEventArgs e)
        {
            var personInfo = (PersonViewModel)BindingContext;
            personInfo.ToggleFavorite();
            favoriteLabel.Text = personInfo.IsFavorite ? "Added to favorites" : "Not in favorites";
            Navigation.PopAsync();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var property = (PersonViewModel.Property)e.SelectedItem;
            Debug.WriteLine(string.Format("Property clicked {0} {1}", property.Type, property.Value));

            switch (property.Type)
            {
                case PersonViewModel.PropertyType.Email:
                    App.PhoneFeatureService.Email(property.Value);
                    break;
                case PersonViewModel.PropertyType.Twitter:
                    App.PhoneFeatureService.Tweet(property.Value);
                    break;
                case PersonViewModel.PropertyType.Url:
                    App.PhoneFeatureService.Browse(property.Value);
                    break;
                case PersonViewModel.PropertyType.Phone:
                    App.PhoneFeatureService.Call(property.Value);
                    break;
                case PersonViewModel.PropertyType.Address:
                    App.PhoneFeatureService.Map(property.Value);
                    break;
            }
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void DownloadImage()
        {
            var personInfo = (PersonViewModel)BindingContext;
            var person = personInfo.Person;

            if (person.HasEmail)
            {
                var imageUrl = Gravatar.GetImageUrl(person.Email, IMAGE_SIZE);
                photo.Source = new UriImageSource { Uri = imageUrl };
            }
        }
    }
}
