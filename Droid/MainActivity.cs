﻿using Android.App;
using Android.OS;
using Android.Webkit;

namespace Chart.Droid
{
	[Activity(Label = "Chart", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		WebView _webView;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);

			_webView = (WebView)FindViewById(Resource.Id.webview);
			_webView.Settings.JavaScriptEnabled = true;

			// hardware layer seems to run worse on my phone than software
			_webView.SetLayerType(Android.Views.LayerType.Software, null);

			_webView.LoadUrl("http://pelican-chart-demo.azurewebsites.net/Chart/Ciq?x=1s");
		}
	}
}