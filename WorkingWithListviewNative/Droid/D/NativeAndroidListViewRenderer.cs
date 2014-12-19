﻿using System;
using Xamarin.Forms;
using WorkingWithListviewPerf;
using WorkingWithListviewPerf.Droid;
using Xamarin.Forms.Platform.Android;
using System.Collections;
using System.Linq;

[assembly: ExportRenderer (typeof (NativeListView2), typeof (NativeAndroidListViewRenderer))]

namespace WorkingWithListviewPerf.Droid
{
	public class NativeAndroidListViewRenderer : ViewRenderer<NativeListView2, global::Android.Widget.ListView>
	{
		public NativeAndroidListViewRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<NativeListView2> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				SetNativeControl (new global::Android.Widget.ListView (Forms.Context));
			}

			if (e.OldElement != null) {
				// unsubscribe
				Control.ItemClick -= clicked;
			}

			if (e.NewElement != null) {
				// subscribe
				Control.Adapter = new NativeAndroidListViewAdapter (Forms.Context as Android.App.Activity, e.NewElement);
				Control.ItemClick += clicked;
			}
		}

//		public override void Layout (int l, int t, int r, int b)
//		{
//			base.Layout (l, t, r, b);
//		}

		void clicked (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) {
			Element.NotifyItemSelected (Element.Items.ToList()[e.Position]);
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			if (e.PropertyName == NativeListView.ItemsProperty.PropertyName) {
				// update the Items list in the UITableViewSource

				Control.Adapter = new NativeAndroidListViewAdapter (Forms.Context as Android.App.Activity, Element);
			}
		}
	}
}