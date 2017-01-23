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

namespace Naivedyam.Droid.Base
{
    [Activity(Label = "ActivityBase")]
    public class ActivityBase : Activity
    {
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbarmenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            if (item.ItemId == Resource.Id.checkOut)
            {
                StartActivity(new Intent(this, typeof(ViewCartActivity)));
            }
            return base.OnMenuItemSelected(featureId, item);
        }
    }
}