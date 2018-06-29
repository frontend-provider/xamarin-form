﻿using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;

using Xamarin.Forms;

using SkiaSharpFormsDemos.UWP;

[assembly: Dependency(typeof(PhotoLibrary))]
namespace SkiaSharpFormsDemos.UWP
{
    public class PhotoLibrary : IPhotoLibrary
    {
        public async Task<Stream> PickPhotoAsync()
        {
            // Create and initialize the FileOpenPicker
            FileOpenPicker openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
            };

            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            // Get a file and return a Stream 
            StorageFile storageFile = await openPicker.PickSingleFileAsync();

            if (storageFile == null)
            {
                return null;
            }

            IRandomAccessStreamWithContentType raStream = await storageFile.OpenReadAsync();
            return raStream.AsStreamForRead();
        }

        public async Task<bool> SavePhotoAsync(byte[] data, string folder, string filename)
        {
            StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
            StorageFolder spinPaintFolder = null;

            // Get the folder or create it if necessary
            try
            {
                spinPaintFolder = await picturesFolder.GetFolderAsync(folder);
            }
            catch
            { }

            if (spinPaintFolder == null)
            {
                try
                {
                    spinPaintFolder = await picturesFolder.CreateFolderAsync(folder);
                }
                catch
                {
                    return false;
                }
            }

            try
            {
                // Create the file.
                StorageFile storageFile = await spinPaintFolder.CreateFileAsync(filename);

                // Convert byte[] to Windows buffer and write it out.
                IBuffer buffer = WindowsRuntimeBuffer.Create(data, 0, data.Length, data.Length);
                await FileIO.WriteBufferAsync(storageFile, buffer);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}