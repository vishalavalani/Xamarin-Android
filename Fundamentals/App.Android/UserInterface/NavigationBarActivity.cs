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

namespace AppAndroid.UserInterface
{
    [Activity(Label = "NavigationBarActivity")]
    public class NavigationBarActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.navigationbar);
            // Create your application here

            var tv = FindViewById<TextView>(Resource.Id.systemUiFlagTextView);
            var lowProfileButton = FindViewById<Button>(Resource.Id.lowProfileButton);
            var hideNavButton = FindViewById<Button>(Resource.Id.hideNavigation);
            var visibleButton = FindViewById<Button>(Resource.Id.visibleButton);

            lowProfileButton.Click += delegate
            {
                tv.SystemUiVisibility =
                    (StatusBarVisibility)SystemUiFlags.LowProfile;
            };

            hideNavButton.Click += delegate
            {
                tv.SystemUiVisibility =
                   (StatusBarVisibility)SystemUiFlags.HideNavigation;
            };

            visibleButton.Click += delegate
            {
                //View.SystemUiFlagVisible
                tv.SystemUiVisibility = (StatusBarVisibility)View.SystemUiFlagVisible;
            };
            tv.SystemUiVisibilityChange +=
              delegate (object sender, View.SystemUiVisibilityChangeEventArgs e)
              {
                  tv.Text = String.Format("Visibility = {0}", e.Visibility);
              };
        }
    }
}