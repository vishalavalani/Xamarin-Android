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
using Android.Util;

namespace Fundamentals.Droid
{
    [Activity(Label = "LifeCycleActivityB")]
    public class LifeCycleActivityB : Activity
    {
        string LogActivityName = "ActivityB";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LifecycleActivityB);
            Log.Debug(LogActivityName, "Activity B - OnCreate");
        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug(LogActivityName, "Activity B - OnStart");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(LogActivityName, "Activity B - OnResume");
        }

        protected override void OnPause()
        {
            base.OnPause();
            Log.Debug(LogActivityName, "Activity B - OnPause");
        }

        protected override void OnStop()
        {
            base.OnStop();
            Log.Debug(LogActivityName, "Activity B - OnStop");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug(LogActivityName, "Activity B - OnDestroy");
        }
    }
}