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
    [Activity(Label = "TabDemoActivity")]
    public class TabDemoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.tabmain);
            // Create your application here
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Tab 1", Resource.Drawable.Icon, new SimpleTabFragment1());
            AddTab("Tab 2", Resource.Drawable.Icon, new SimpleTabFragment2());

            if (savedInstanceState != null)
                this.ActionBar.SelectTab(this.ActionBar.GetTabAt(savedInstanceState.GetInt("tab")));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbarmenu, menu);
            var shareMenuItem = menu.FindItem(Resource.Id.shareMenuItem);
            var shareActionProvider =
               (ShareActionProvider)shareMenuItem.ActionProvider;
            shareActionProvider.SetShareIntent(CreateIntent());

            return base.OnCreateOptionsMenu(menu);
        }

        Intent CreateIntent()
        {
            var sendPictureIntent = new Intent(Intent.ActionSend);
            //sendPictureIntent.SetType("image/*");
            //var uri = Android.Net.Uri.FromFile(GetFileStreamPath("monkey.png"));
            //sendPictureIntent.PutExtra(Intent.ExtraStream, uri);
            return sendPictureIntent;
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);
            base.OnSaveInstanceState(outState);
        }


        void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(Resource.Drawable.Icon);

            tab.TabSelected += (object sender, ActionBar.TabEventArgs e) =>
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += (object sender, ActionBar.TabEventArgs e) =>
            {
                e.FragmentTransaction.Remove(view);
            };

            ActionBar.AddTab(tab);
        }

        class SimpleTabFragment1 : Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);

                var view = inflater.Inflate(Resource.Layout.tab, container, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);
                sampleTextView.Text = "Fragment 1";

                return view;
            }
        }

        class SimpleTabFragment2 : Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);

                var view = inflater.Inflate(Resource.Layout.tab, container, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);
                sampleTextView.Text = "Fragment 2";

                return view;
            }
        }


    }
}