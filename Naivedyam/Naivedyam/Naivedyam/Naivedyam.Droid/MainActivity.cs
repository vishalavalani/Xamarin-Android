using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Widget;
using Naivedyam.Droid.Adapters;
using Naivedyam.Droid.Base;

namespace Naivedyam.Droid
{
	[Activity (Label = "Naivedyam", Icon = "@drawable/Icon")]
	public class MainActivity : BaseFragmentActivity
    {
        Android.Support.V4.App.FragmentTransaction transaction;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainBase);
            ActionBar actionBar = this.ActionBar;

            LeftNavAdapter adapter = new LeftNavAdapter(this);
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            GridView list = FindViewById<GridView>(Resource.Id.drawer);
            list.Adapter = adapter;
            list.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
            {

            };

            transaction = SupportFragmentManager.BeginTransaction();
            var obj = new MainFragmentActivity();
            obj.RetainInstance = false;
            transaction.Add(Resource.Id.mainframe, obj);
            transaction.Commit();
        }

    }
}


