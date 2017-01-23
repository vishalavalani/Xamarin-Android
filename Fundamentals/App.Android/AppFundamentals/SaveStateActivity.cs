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

namespace AppAndroid.AppFundamentals
{
    [Activity(Label = "SaveStateActivity")]
    public class SaveStateActivity : Activity
    {
        int counter = 0;
        Button btnCounter;
        TextView txtCounter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.savestate);

            btnCounter = FindViewById<Button>(Resource.Id.btnCounter);
            txtCounter = FindViewById<TextView>(Resource.Id.txtCounter);
            //if (savedInstanceState != null)
            //{
            //    //counter = savedInstanceState.GetInt("counter");
            //    txtCounter.Text = counter.ToString();
            //}
            btnCounter.Click += (object sender, EventArgs e) =>
            {
                counter++;
                txtCounter.Text = counter.ToString();
            };
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("counter", counter);
            base.OnSaveInstanceState(outState);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            counter = savedInstanceState.GetInt("counter");
            txtCounter.Text = counter.ToString();
            base.OnRestoreInstanceState(savedInstanceState);
        }

    }
}