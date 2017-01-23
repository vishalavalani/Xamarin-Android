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
using Naivedyam.Droid.Adapters;
using Naivedyam.Droid.Data;
using Naivedyam.Droid.Models;
using Android.Support.V4.Widget;
using Naivedyam.Droid.Base;

namespace Naivedyam.Droid
{
    [Activity(Label = "Place Order")]
    public class OrderActivity : ActivityBase
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.order);
            this.ActionBar.SetDisplayHomeAsUpEnabled(true);
            this.ActionBar.NavigationMode = Android.App.ActionBarNavigationMode.Tabs;

            AddTab("Idli", Resource.Drawable.idli, new IdliFragment());
            AddTab("Vada", Resource.Drawable.vada, new VadaFragment());
            AddTab("Upma", Resource.Drawable.upma, new UpmaFragment());
            AddTab("Dosa", Resource.Drawable.dosa, new DosaFragment());

            if (savedInstanceState != null)
                this.ActionBar.SelectTab(this.ActionBar.GetTabAt(savedInstanceState.GetInt("tab")));
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);
            base.OnSaveInstanceState(outState);
        }


        public class IdliFragment : Android.App.Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                var view = inflater.Inflate(Resource.Layout.tab, container, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);
                sampleTextView.Text = "Idli";
                sampleTextView.Visibility = ViewStates.Gone;
                var listMenuItems = view.FindViewById<ListView>(Resource.Id.ListMenuItems);
                listMenuItems.Adapter = new MenuAdapter(this.Activity, DataHelper.idliItems);
                listMenuItems.ItemClick += IdliListMenuItems_ItemClick;
                return view;
            }

            private void IdliListMenuItems_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
            {
                int menuitemid = DataHelper.idliItems[e.Position].MenuItemID;
                Intent i = new Intent(this.Activity, typeof(MenuItemDetailActivity));
                i.PutExtra("menuitemid", menuitemid.ToString());
                StartActivity(i);
            }
        }

        public class VadaFragment : Android.App.Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                var view = inflater.Inflate(Resource.Layout.tab, container, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);

                sampleTextView.Text = "Vada";
                sampleTextView.Visibility = ViewStates.Gone;
                var listMenuItems = view.FindViewById<ListView>(Resource.Id.ListMenuItems);
                listMenuItems.Adapter = new MenuAdapter(this.Activity, DataHelper.vadaItems);
                listMenuItems.ItemClick += VadaListMenuItems_ItemClick;
                return view;
            }
            private void VadaListMenuItems_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
            {
                int menuitemid = DataHelper.vadaItems[e.Position].MenuItemID;
                Intent i = new Intent(this.Activity, typeof(MenuItemDetailActivity));
                i.PutExtra("menuitemid", menuitemid.ToString());
                StartActivity(i);
            }
        }

        public class UpmaFragment : Android.App.Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                var view = inflater.Inflate(Resource.Layout.tab, container, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);
                sampleTextView.Text = "Upma";
                sampleTextView.Visibility = ViewStates.Gone;
                var listMenuItems = view.FindViewById<ListView>(Resource.Id.ListMenuItems);
                listMenuItems.Adapter = new MenuAdapter(this.Activity, DataHelper.upmaItems);
                listMenuItems.ItemClick += UpmaListMenuItems_ItemClick;
                return view;
            }
            private void UpmaListMenuItems_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
            {
                int menuitemid = DataHelper.upmaItems[e.Position].MenuItemID;
                Intent i = new Intent(this.Activity, typeof(MenuItemDetailActivity));
                i.PutExtra("menuitemid", menuitemid.ToString());
                StartActivity(i);
            }
        }

        public class DosaFragment : Android.App.Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                var view = inflater.Inflate(Resource.Layout.tab, container, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);
                sampleTextView.Text = "Dosa";
                sampleTextView.Visibility = ViewStates.Gone;
                var listMenuItems = view.FindViewById<ListView>(Resource.Id.ListMenuItems);
                listMenuItems.Adapter = new MenuAdapter(this.Activity, DataHelper.dosaItems);
                listMenuItems.ItemClick += DosaListMenuItems_ItemClick;
                return view;
            }
            private void DosaListMenuItems_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
            {
                int menuitemid = DataHelper.dosaItems[e.Position].MenuItemID;
                Intent i = new Intent(this.Activity, typeof(MenuItemDetailActivity));
                i.PutExtra("menuitemid", menuitemid.ToString());
                StartActivity(i);
            }
        }

        void AddTab(string tabText, int iconResourceId, Android.App.Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += (object sender, Android.App.ActionBar.TabEventArgs e) =>
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += (object sender, Android.App.ActionBar.TabEventArgs e) =>
            {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }



       

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    this.Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}