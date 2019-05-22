﻿using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlatformSpecifics
{
    public class AndroidTabbedPageSwipePageCS : Xamarin.Forms.TabbedPage
    {
        ICommand _returnToPlatformSpecificsPage;

        public AndroidTabbedPageSwipePageCS(ICommand restore)
        {
            _returnToPlatformSpecificsPage = restore;

            On<Android>().SetOffscreenPageLimit(2)
                         .SetIsSwipePagingEnabled(true)
                         .SetIsSmoothScrollEnabled(false)
                         .SetToolbarPlacement(ToolbarPlacement.Bottom);

            var firstPage = CreatePage(1);
            var stackLayout = firstPage.Content as StackLayout;
            var swipePagingButton = new Xamarin.Forms.Button
            {
                Text = "Toggle Swipe Paging"
            };
            swipePagingButton.Clicked += (sender, e) =>
            {
                On<Android>().SetIsSwipePagingEnabled(!On<Android>().IsSwipePagingEnabled());
            };
            var smoothScrollButton = new Xamarin.Forms.Button
            {
                Text = "Toggle Smooth Scroll"
            };
            smoothScrollButton.Clicked += (sender, e) =>
            {
                On<Android>().SetIsSmoothScrollEnabled(!On<Android>().IsSmoothScrollEnabled());
            };

            stackLayout.Children.Add(swipePagingButton);
            stackLayout.Children.Add(smoothScrollButton);

            Title = "TabbedPage";
            Children.Add(firstPage);
            Children.Add(CreatePage(2));
            Children.Add(CreatePage(3));
            Children.Add(CreatePage(4));
            Children.Add(CreatePage(5));
        }

        ContentPage CreatePage(int pageNumber)
        {
            var returnButton = new Xamarin.Forms.Button { Text = "Return to Platform-Specifics List" };
            returnButton.Clicked += (sender, e) => _returnToPlatformSpecificsPage.Execute(null);

            return new ContentPage
            {
                Title = string.Format("Page {0}", pageNumber),
                IconImageSource = "csharp.png",
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children = {
                        new Label { Text = string.Format("Page {0}", pageNumber), HorizontalOptions = LayoutOptions.Center },
                        returnButton
                    }
                }
            };
        }
    }
}
