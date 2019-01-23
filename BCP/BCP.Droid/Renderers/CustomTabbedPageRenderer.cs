//using System;
//using System.ComponentModel;
//using Android.App;
//using Android.Graphics.Drawables;
//using Android.Support.V7.App;
//using Android.Views;
//using BCP.Droid.Renderers;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]
//namespace BCP.Droid.Renderers
//{
//    public class CustomTabbedPageRenderer : TabbedRenderer
//    {
//		//This flag is used in the case when the app is not completely closed, and the user return back.
//		private bool isFirstDesign = true;

//        private AppCompatActivity activity;

//        private const string COLOR = "#f7f8f8";

//		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
//		{
//			base.OnElementPropertyChanged(sender, e);
//			activity = this.Context as AppCompatActivity;
//		}

//		protected override void OnWindowVisibilityChanged(ViewStates visibility)
//		{
//			base.OnWindowVisibilityChanged(visibility);
//			if (isFirstDesign)
//			{
//                Android.Support.V7.App.ActionBar actionBar = activity.SupportActionBar;

//				ColorDrawable colorDrawable = new ColorDrawable(Android.Graphics.Color.ParseColor(COLOR));
//				actionBar.SetStackedBackgroundDrawable(colorDrawable);
//				//ActionBarTabsSetup(actionBar);

//				isFirstDesign = false;
//			}
//		}

//    }
//}
