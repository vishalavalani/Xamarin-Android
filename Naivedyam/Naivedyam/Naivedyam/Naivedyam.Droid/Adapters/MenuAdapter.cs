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
using Naivedyam.Droid.Data;
using Naivedyam.Droid.Models;

namespace Naivedyam.Droid.Adapters
{
    public class MenuAdapter : BaseAdapter<MenuItem>
    {
        Activity _context;
        List<MenuItem> _items;
        public MenuAdapter(Activity context, List<MenuItem> items)
        {
            _context = context;
            _items = items;
        }
        public override MenuItem this[int position]
        {
            get
            {
                return _items[position];
            }
        }

        public override int Count
        {
            get
            {
                return _items.Count();
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];
            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.listcustomcell, null);

            view.FindViewById<TextView>(Resource.Id.textViewHeading).Text = _items[position].Name;
            view.FindViewById<TextView>(Resource.Id.textViewSubHeading).Text = _items[position].Description;
            view.FindViewById<TextView>(Resource.Id.textViewPrice).Text = "Rs. " + Convert.ToString(_items[position].Price);
            view.FindViewById<ImageView>(Resource.Id.imageViewMenuItem).SetImageResource(_items[position].ImageID);
            return view;
        }
    }
}