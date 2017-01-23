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
    [Activity(Label = "Activity A")]
    public class LifecycleActivityA : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Log.Debug(GetType().FullName, "Activity A - OnCreate");
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LifecycleActivityA);

            Button btnGoToActivityB = FindViewById<Button>(Resource.Id.btnGoToActivityB);
            btnGoToActivityB.Click += BtnGoToActivityB_Click;
        }

        private void BtnGoToActivityB_Click(object sender, EventArgs e)
        {
            Intent activityB = new Intent(this, typeof(LifecycleActivityB));
            StartActivity(activityB);
        }

        protected override void OnStart()
        {
            Log.Debug(GetType().FullName, "Activity A - OnStart");
            base.OnStart();
        }

        protected override void OnPause()
        {
            Log.Debug(GetType().FullName, "Activity A - OnPause");
            base.OnPause();
        }

        protected override void OnResume()
        {
            Log.Debug(GetType().FullName, "Activity A - OnResume");
            base.OnResume();
        }

        protected override void OnRestart()
        {
            Log.Debug(GetType().FullName, "Activity A - OnRestart");
            base.OnRestart();
        }
        protected override void OnStop()
        {
            Log.Debug(GetType().FullName, "Activity A - OnStop");
            base.OnStop();
        }

        protected override void OnDestroy()
        {
            Log.Debug(GetType().FullName, "Activity A - OnDestroy");
            base.OnDestroy();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            Log.Debug(GetType().FullName, "Activity A - OnSaveInstanceState");
            base.OnSaveInstanceState(outState);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            Log.Debug(GetType().FullName, "Activity A - OnRestoreInstanceState");
            base.OnRestoreInstanceState(savedInstanceState);
        }
    }
}