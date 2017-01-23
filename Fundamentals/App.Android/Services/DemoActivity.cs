using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppAndroid.Services
{
    [Activity(Label = "DemoActivity")]
    public class DemoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.demoservice);
            // Create your application here

            var start = FindViewById<Button>(Resource.Id.startService);
            var stop = FindViewById<Button>(Resource.Id.stopService);

            start.Click += delegate {
                StartService (new Intent (this, typeof(DemoService)));
            };

            stop.Click += delegate {
                StopService (new Intent (this, typeof(DemoService)));
            };
        }
    }
}