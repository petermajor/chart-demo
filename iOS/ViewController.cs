using System;
using Foundation;
using UIKit;
using WebKit;

namespace Chart.iOS
{
	public partial class ViewController : UIViewController, IWKNavigationDelegate//, IWKScriptMessageHandler
	{
		WKWebView _webView;


		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var config = new WKWebViewConfiguration();
			//config.UserContentController.AddScriptMessageHandler(this, "interOp");

			_webView = new WKWebView(View.Frame, config);
			_webView.NavigationDelegate = this;
			_webView.TranslatesAutoresizingMaskIntoConstraints = false;
			View.AddSubview(_webView);

			var keys = new object[] { "webview" };
			var objects = new object[] { _webView };
			var myViews = NSDictionary.FromObjectsAndKeys(objects, keys);

			//horizontal layout
			View.AddConstraints(NSLayoutConstraint.FromVisualFormat(@"|[webview]|", 0, null, myViews));
			//vertical layout
			View.AddConstraints(NSLayoutConstraint.FromVisualFormat(@"V:|-44-[webview]|", 0, null, myViews));

			var url = new NSUrl("http://pelican-chart-demo.azurewebsites.net/Chart/Ciq?x=1s");
			var request = new NSUrlRequest(url);
			_webView.LoadRequest(request);
		}

		//[Export("userContentController:didReceiveScriptMessage:")]
		//public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
		//{
		//	var sentData = (NSDictionary)message.Body;
		//	var aCount = sentData["count"];
		//	//aCount++;
		//	_webView.EvaluateJavaScript($"storeAndShow({aCount})", null);
		//}

		//[Export("webView:didFinishNavigation:")]
		//public void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
		//{
		//	_webView.EvaluateJavaScript("resize()", (result, error) => Debug.WriteLine($"error: {error}"));
		//}

		//public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
		//{
		//	_webView.EvaluateJavaScript("resize()", (result, error) => Debug.WriteLine($"error: {error}"));
		//}
	}
}
