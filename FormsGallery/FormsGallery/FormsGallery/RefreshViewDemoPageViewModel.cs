﻿using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Threading.Tasks;

namespace FormsGallery
{
    public class RefreshViewDemoPageViewModel : INotifyPropertyChanged
    {
        const int RefreshDuration = 2;
        int itemNumber = 1;
        readonly Random random;
        bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<RefreshItem> Items { get; private set; }

        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());

        public RefreshViewDemoPageViewModel()
        {
            random = new Random();
            Items = new ObservableCollection<RefreshItem>();
            AddItems();
        }

        void AddItems()
        {
            for (int i = 0; i < 50; i++)
            {
                Items.Add(new RefreshItem
                {
                    Color = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)),
                    Name = $"Item {itemNumber++}"
                });
            }
        }

        async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            AddItems();
            IsRefreshing = false;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

