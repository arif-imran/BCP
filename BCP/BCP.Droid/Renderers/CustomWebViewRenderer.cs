using System;
using System.Threading;
using System.Threading.Tasks;
using Android.Webkit;
using BCP.Droid.Renderers;
using BCP.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
//namespace BCP.Droid.Renderers
//{
//    public class CustomWebViewRenderer : WebViewRenderer
//    {
//        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
//        {
//            	base.OnElementChanged(e);

//                      var webView = e.NewElement as CustomWebView;
//            	if (webView != null)
//            		webView.EvaluateJavascript = async (js) =>
//            		{
//            			var reset = new ManualResetEvent(false);
//            			var response = string.Empty;
//            			Device.BeginInvokeOnMainThread(() =>
//            			{
//            				Control?.EvaluateJavascript(js, new JavascriptCallback((r) => { response = r; reset.Set(); }));
//            			});
//            			await Task.Run(() => { reset.WaitOne(); });
//            			return response;
//            		};
//            }
//        }

//        internal class JavascriptCallback : Java.Lang.Object, IValueCallback
//        {
//            public JavascriptCallback(Action<string> callback)
//            {
//                _callback = callback;
//            }

//            private Action<string> _callback;
//            public void OnReceiveValue(Java.Lang.Object value)
//            {
//                _callback?.Invoke(Convert.ToString(value));
//            }
//        }
//    }
//}
