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
	[Activity(Label = "LifeCycleActivityA", Icon = "@drawable/icon")]
	public class LifeCycleActivityA : Activity
	{
		string LogActivityName = "ActivityA";
		Button btnclickcounter;
		TextView lblclickCounter;
		int clickCount = 0;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.LifecycleActivityA);
			Log.Debug(LogActivityName, "Activity A - OnCreate");

			Button gotoactivityb = this.FindViewById<Button>(Resource.Id.gotoactivityb);
			btnclickcounter = this.FindViewById<Button>(Resource.Id.btnclickcounter);
			lblclickCounter = this.FindViewById<TextView>(Resource.Id.lblclickCounter);
			gotoactivityb.Click += Gotoactivityb_Click;
			btnclickcounter.Click += Btnclickcounter_Click;

		}

		protected override void OnRestoreInstanceState(Bundle savedInstanceState)
		{
			Log.Debug(LogActivityName, "Activity A - OnRestoreInstanceState");
			base.OnRestoreInstanceState(savedInstanceState);
			if (savedInstanceState != null)
			{
				clickCount = savedInstanceState.GetInt("clickCount");
				lblclickCounter.Text = savedInstanceState.GetInt("clickCount").ToString();
			}
		}

		void Btnclickcounter_Click(object sender, EventArgs e)
		{
			clickCount++;
			lblclickCounter.Text = clickCount.ToString();
		}

		private void Gotoactivityb_Click(object sender, EventArgs e)
		{
			Intent activityB = new Intent(this, typeof(LifeCycleActivityB));
			StartActivity(activityB);
		}

		protected override void OnStart()
		{
			base.OnStart();
			Log.Debug(LogActivityName, "Activity A - OnStart");
		}

		protected override void OnResume()
		{
			base.OnResume();
			Log.Debug(LogActivityName, "Activity A - OnResume");
		}

		protected override void OnPause()
		{
			base.OnPause();
			Log.Debug(LogActivityName, "Activity A - OnPause");
		}

		protected override void OnStop()
		{
			base.OnStop();
			Log.Debug(LogActivityName, "Activity A - OnStop");
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Log.Debug(LogActivityName, "Activity A - OnDestroy");
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			Log.Debug(LogActivityName, "Activity A - OnSaveInstanceState");
			outState.PutInt("clickCount", clickCount);
			base.OnSaveInstanceState(outState);
		}
	}
}