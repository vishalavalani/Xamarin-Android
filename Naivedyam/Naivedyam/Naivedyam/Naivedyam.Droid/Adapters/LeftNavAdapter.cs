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
using Java.Lang;

namespace Naivedyam.Droid.Adapters
{
    public class LeftNavAdapter : BaseAdapter
    {
        private Activity _context;
        private readonly int[] thumbIds = {
            0,
            0,
            0,
            0,
            0
        };
        private readonly string[] Headings = {
            "Place Your Order",
            "View Your Cart",
            "Take A Pic",
            "Go To Naivedyam",
            "About Naivedyam"
        };


        public LeftNavAdapter(Activity context)
        {
            _context = context;
        }
        public override int Count
        {
            get
            {
                return thumbIds.Length;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            int actualicon = thumbIds[position];
            string actualHeading = Headings[position];
            convertView = _context.LayoutInflater.Inflate(Resource.Layout.NavigationCell, null);
            TextView heading = convertView.FindViewById<TextView>(Resource.Id.heading);
            ImageView icon = convertView.FindViewById<ImageView>(Resource.Id.icon);
            if (actualicon == 0)
            {
                icon.Visibility = ViewStates.Gone;
            }

            heading.Text = actualHeading;
            return convertView;
        }
    }
}