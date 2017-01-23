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
    [Activity(Label = "GlobalDemoActivity")]
    public class GlobalDemoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.demoservice);

            var start = FindViewById<Button>(Resource.Id.startService);
            var stop = FindViewById<Button>(Resource.Id.stopService);

            start.Click += delegate {
                StartService(new Intent(("com.alept.DemoService")));
            };

            stop.Click += delegate {
                StopService(new Intent(("com.alept.DemoService")));
            };
        }
    }
}