---
name: Xamarin.Forms - TodoLocalized RTL
description: 'Todo list Android & iOS app that supports right-to-left UI layout and translation to languages like Arabic & Hebrew'
page_type: sample
languages:
- csharp
products:
- xamarin
urlFragment: todolocalizedrtl
---
# Xamarin.Forms TodoLocalized Right-to-Left (RTL) user interface layout

This sample demonstrates how to right-to-left localize Xamarin.Forms apps.

![iOS screenshot showing right-to-left language layout](Screenshots/02ar-small.png)

This sample uses [Multilingual App Toolkit (MAT) from Microsoft](https://dev.windows.com/en-us/develop/multilingual-app-toolkit) (specifically the [v4.0 Technical Preview](https://visualstudiogallery.msdn.microsoft.com/6dab9154-a7e1-46e4-bbfa-18b5e81df520))to localize a Xamarin.Forms application for iOS, Android, and the Universal Windows Platform. You do NOT need MAT to build or run this sample.

You can learn about MAT here:

* [Introduction to MAT video](https://channel9.msdn.com/Series/Introducing-Windows-8/Introduction-to-the-Multilingual-App-Toolkit)

* [MAT and Xamarin blog post](http://blogs.msdn.com/b/matdev/archive/2014/10/08/mat-v4-0-technical-preview-adds-xamarin-support.aspx)

* [Download Multilingual App Toolkit (MAT) v4.0 for Windows](https://visualstudiogallery.msdn.microsoft.com/6dab9154-a7e1-46e4-bbfa-18b5e81df520)

**MAT** stores language information in [XLIFF](https://www.oasis-open.org/committees/tc_home.php?wg_abbrev=xliff) (.xlf) files which are parsed into RESX files at build time. It is the RESX files that are loaded by the application to render the translated user-interface. The XLIFF files are **edited in Visual Studio** and the build step that transforms them only runs there, so language data should only be edited on Windows... luckily this runs in Visual Studio Express. You can then push your app (including the generated RESX files) into source control - they'll work fine for iOS, Android, and Windows Phone projects.

