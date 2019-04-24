﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ImageWrapLayout
{
    public class ImageWrapLayoutPageCS : ContentPage
	{
        HttpClient _client;
        WrapLayout _wrapLayout;

		public ImageWrapLayoutPageCS()
		{
			_wrapLayout = new WrapLayout();

			Content = new ScrollView
			{
				Margin = new Thickness(20, 35, 20, 20),
				Content = _wrapLayout
			};

            _client = new HttpClient();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var images = await GetImageListAsync();
            if (images != null)
            {
                foreach (var photo in images.Photos)
                {
                    var image = new Image
                    {
                        Source = ImageSource.FromUri(new Uri(photo))
                    };
                    _wrapLayout.Children.Add(image);
                }
            }
        }

        async Task<ImageList> GetImageListAsync()
        {
            try
            {
                string requestUri = "https://raw.githubusercontent.com/xamarin/docs-archive/master/Images/stock/small/stock.json";
                string result = await _client.GetStringAsync(requestUri);
                return JsonConvert.DeserializeObject<ImageList>(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"\tERROR: {ex.Message}");
            }

            return null;
        }
    }
}
