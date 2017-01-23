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
using Naivedyam.Droid.Models;
using Naivedyam.Droid.Data;

namespace Naivedyam.Droid.Adapters
{
    class CartAdapter : BaseAdapter<Cart>
    {
        public event EventHandler<EventArgs> ItemRemoved = delegate { };
        Activity _context;
        List<Cart> _items;
        AlertDialog.Builder _alert;
        public CartAdapter(Activity context, List<Cart> items)
        {
            _context = context;
            _items = items;
            _alert = new AlertDialog.Builder(_context);
        }
        public override Cart this[int position]
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
                return _items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];
            int menuitemid = _items[position].MenuItemID;
            int qty = _items[position].Quantity;
            var menuitem = DataHelper.MenuItems.Where(d => d.MenuItemID == menuitemid).FirstOrDefault();

            View view = convertView;
            if(view == null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.cartcustomcell, null);
                var btnRemove = view.FindViewById<ImageButton>(Resource.Id.imageButtonRemove);
                btnRemove.Click += (object sender, EventArgs e) =>
                {
                    _alert.SetMessage("Are you sure you want to remove " + menuitem.Name + "?");
                    _alert.SetNeutralButton("Yes", delegate
                    {
                        var toRemovebj = _items[position];
                        this._items.Remove(toRemovebj);
                        this.ItemRemoved(this, e);
                        this.NotifyDataSetChanged();
                    });

                    _alert.SetNegativeButton("No", delegate { });
                    _alert.Show();
                };
            }

            view.FindViewById<TextView>(Resource.Id.textViewCartHeading).Text = menuitem.Name;
            view.FindViewById<TextView>(Resource.Id.textViewCartPrice).Text = Convert.ToString(menuitem.Price);
            view.FindViewById<TextView>(Resource.Id.textViewCartQty).Text = Convert.ToString(qty);
            view.FindViewById<ImageView>(Resource.Id.imageViewCartItem).SetImageResource(menuitem.ImageID);
            
            return view;
        }

    }
}