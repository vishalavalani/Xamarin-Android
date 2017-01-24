
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Fundamentals.Droid
{
	[Activity(Label = "RotationActivity", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
	public class RotationActivity : Activity
	{
		string tag = "RotationActivity";
		TextView textView1;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Rotation);
			textView1 = FindViewById<TextView>(Resource.Id.textView1);
			// Create your application here
			var surfaceOrientation = WindowManager.DefaultDisplay.Rotation;
			if (surfaceOrientation == SurfaceOrientation.Rotation0 || surfaceOrientation == SurfaceOrientation.Rotation180)
			{
				textView1.Text = "Landscape";
				Log.Debug(tag, "Landscape");
				//tvLayoutParams = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.WrapContent);
			}
			else {
				textView1.Text = "Portrait";
				Log.Debug(tag, "Portrait");
				//tvLayoutParams = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.WrapContent);
				//tvLayoutParams.LeftMargin = 100;
				//tvLayoutParams.TopMargin = 100;
			}
		}

		public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);
			if (newConfig.Orientation == Android.Content.Res.Orientation.Portrait)
			{
				textView1.Text = "Portrait";
			}
			else
			{
				textView1.Text = "Landscape";
			}
		}
	}
}
