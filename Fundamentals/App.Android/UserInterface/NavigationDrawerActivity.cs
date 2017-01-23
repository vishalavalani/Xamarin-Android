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
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;

//Ambiguities
using Fragment = Android.App.Fragment;

namespace AppAndroid.UserInterface
{
    [Activity(Label = "NavigationDrawerActivity")]
    public class NavigationDrawerActivity : Activity
    {
        private DrawerLayout mDrawerLayout;
        private RecyclerView mDrawerList;
        private ActionBarDrawerToggle mDrawerToggle;

        private string mDrawerTitle;
        private String[] mPlanetTitles;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_navigation_drawer);

            mDrawerTitle = this.Title;
            mPlanetTitles = this.Resources.GetStringArray(Resource.Array.planets_array);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mDrawerList = FindViewById<RecyclerView>(Resource.Id.left_drawer);
        }
    }
}