﻿using System;
using System.IO;
using Foundation;
using Notes.Controllers;
using Notes.iOS.Models;
using Notes.iOS.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Notes.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public static AppDelegate Instance;
        UIWindow _window;
        AppNavigationController _navigation;

        public static string FolderPath { get; private set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Forms.Init();

            Instance = this;
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.Black
            });

            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            UIViewController mainPage = new NotesPage().CreateViewController();
            mainPage.Title = "Notes";

            _navigation = new AppNavigationController(mainPage);

            _window.RootViewController = _navigation;
            _window.MakeKeyAndVisible();

            return true;
        }

        public void NavigateToNoteEntryPage(Note note)
        {
            var noteEntryPage = new NoteEntryPage
            {
                BindingContext = note
            }.CreateViewController();
            noteEntryPage.Title = "Note Entry";
            _navigation.PushViewController(noteEntryPage, true);
        }

        public void NavigateBack()
        {
            _navigation.PopViewController(true);
        }
    }
}