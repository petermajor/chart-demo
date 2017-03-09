using System;

using UIKit;
using WebKit;
using Foundation;
using System.Diagnostics;
using System.IO;

namespace Chart.iOS
{
	public partial class ViewController : UIViewController, IWKScriptMessageHandler, IWKNavigationDelegate
	{
		WKWebView _webView;


		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var config = new WKWebViewConfiguration();
			config.UserContentController.AddScriptMessageHandler(this, "interOp");

			//var styleFile = NSBundle.MainBundle.PathForResource("theme", "js");
			//var style = new NSString(File.ReadAllText(styleFile));
			//var script = new WKUserScript(style, WKUserScriptInjectionTime.AtDocumentEnd, false);
			//config.UserContentController.AddUserScript(script);

			_webView = new WKWebView(View.Frame, config);
			_webView.NavigationDelegate = this;
			_webView.TranslatesAutoresizingMaskIntoConstraints = false;
			View.AddSubview(_webView);

			var keys = new object[] { "webview" };
			var objects = new object[] { _webView };
			var myViews = NSDictionary.FromObjectsAndKeys(objects, keys);

			//horizontal layout
			View.AddConstraints(NSLayoutConstraint.FromVisualFormat(@"|-20-[webview]-|", 0, null, myViews));
			//vertical layout
			View.AddConstraints(NSLayoutConstraint.FromVisualFormat(@"V:|-44-[webview]-|", 0, null, myViews));

			//_webView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			//View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

			//var url = new NSUrl("https://demo.chartiq.com/chartiq.html");
			var url = new NSUrl("http://demolibrary.chartiq.com/sample-native/ciq-mobile.html");
			var request = new NSUrlRequest(url);
			_webView.LoadRequest(request);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}

		[Export("userContentController:didReceiveScriptMessage:")]
		public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
		{
			var sentData = (NSDictionary)message.Body;
			var aCount = sentData["count"];
			//aCount++;
			_webView.EvaluateJavaScript($"storeAndShow({aCount})", null);
		}

		[Export("webView:didFinishNavigation:")]
		public void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
		{
			_webView.EvaluateJavaScript("resize()", (result, error) => Debug.WriteLine($"error: {error}"));

			var styleFile = NSBundle.MainBundle.PathForResource("style", "js");
			var style = File.ReadAllText(styleFile);
			_webView.EvaluateJavaScript(style, (result, error) => Debug.WriteLine($"error: {error}"));

			//var css = ".stx_candle_down, .stx_line_down { color: #f94949; border-left-color: #000000; } .stx_candle_up, .stx_line_up { color: #0a78fc; border-left-color: #000000; } .stx_candle_shadow, .stx_bar_even { color:#d8d8d8; }";
			//var js = $"var style = document.createElement('style'); style.innerHTML = '{css}'; document.head.appendChild(style);";
			//_webView.EvaluateJavaScript(js, (result, error) => Debug.WriteLine($"error: {error}"));
		}
	}
}
