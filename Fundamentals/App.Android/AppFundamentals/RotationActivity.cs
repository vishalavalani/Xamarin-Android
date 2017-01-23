using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppAndroid.AppFundamentals
{
    [Activity(Label = "RotationActivity", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class RotationActivity : Activity
    {
        TextView textView1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.rotation);
            // Create your application here
            //Getting orientation
            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            var surfaceOrientation = WindowManager.DefaultDisplay.Rotation;

            //if(surfaceOrientation == SurfaceOrientation.Rotation0 || surfaceOrientation == SurfaceOrientation.Rotation180)
            //{
            //    //Do something here..
            //    textView1.Text = "Portrait";
            //}
            //else
            //{
            //    //Do something here..
            //    textView1.Text = "Landscape";
            //}
            
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            if(newConfig.Orientation == Android.Content.Res.Orientation.Landscape)
            {
                textView1.Text = "Landscape";
            }
            if (newConfig.Orientation == Android.Content.Res.Orientation.Portrait)
            {
                textView1.Text = "Portrait";
            }
        }
    }
}