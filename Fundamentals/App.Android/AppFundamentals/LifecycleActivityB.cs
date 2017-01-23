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

namespace AppAndroid.AppFundamentals
{
    [Activity(Label = "Activity B")]
    public class LifecycleActivityB : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Log.Debug(GetType().FullName, "Activity B - OnCreate");
            base.OnCreate(savedInstanceState);
        }

        protected override void OnStart()
        {
            Log.Debug(GetType().FullName, "Activity B - OnStart");
            base.OnStart();
        }

        protected override void OnResume()
        {
            Log.Debug(GetType().FullName, "Activity B - OnResume");
            base.OnResume();
        }

        protected override void OnPause()
        {
            Log.Debug(GetType().FullName, "Activity B - OnPause");
            base.OnPause();
        }

        protected override void OnRestart()
        {
            Log.Debug(GetType().FullName, "Activity B - OnRestart");
            base.OnRestart();
        }
        protected override void OnStop()
        {
            Log.Debug(GetType().FullName, "Activity B - OnStop");
            base.OnStop();
        }

        protected override void OnDestroy()
        {
            Log.Debug(GetType().FullName, "Activity B - OnDestroy");
            base.OnDestroy();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            Log.Debug(GetType().FullName, "Activity B - OnSaveInstanceState");
            base.OnSaveInstanceState(outState);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            Log.Debug(GetType().FullName, "Activity B - OnRestoreInstanceState");
            base.OnRestoreInstanceState(savedInstanceState);
        }
    }
}