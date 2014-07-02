﻿using System;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace WorkingWithFiles
{
	public class LoadResourceXml : ContentPage
	{
		public LoadResourceXml ()
		{
			#region How to load an XML file embedded resource
			var assembly = typeof(LoadResourceText).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("WorkingWithFiles.PCLXmlResource.xml");

			List<Monkey> monkeys;
			using (var reader = new System.IO.StreamReader (stream)) {
				var serializer = new XmlSerializer(typeof(List<Monkey>));
				monkeys = (List<Monkey>)serializer.Deserialize(reader);
			}
			#endregion

			var listView = new ListView ();
			listView.ItemsSource = monkeys;


			Content = new StackLayout {
				Padding = new Thickness (0,20,0,0),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					new Label { Text = "Embedded Resource XML File (PCL)", 
						Font = Font.BoldSystemFontOfSize(NamedSize.Medium) }
					, listView}
			};
		}
	}
}

