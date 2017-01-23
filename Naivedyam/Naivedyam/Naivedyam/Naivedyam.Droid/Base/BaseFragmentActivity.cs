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

namespace Naivedyam.Droid.Base
{
    public class BaseFragmentActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnRestart()
        {
            GridView list = FindViewById<GridView>(Resource.Id.drawer);
            if(list != null)
            {
                list.InvalidateViews();
            }
            this.InvalidateOptionsMenu();
            base.OnRestart();
        }

        protected override void OnResume()
        {
            GridView list = FindViewById<GridView>(Resource.Id.drawer);
            if (list != null)
            {
                list.InvalidateViews();
            }
            this.InvalidateOptionsMenu();
            base.OnResume();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            return base.OnMenuItemSelected(featureId, item);
        }

    }
}