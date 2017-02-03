using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace Fundamentals.Droid
{
	public class ColorAdapter : BaseAdapter<ColorItem>
	{
		List<ColorItem> items;
		Activity context;
		public ColorAdapter(Activity context, List<ColorItem> items) : base()
		{
			this.context = context;
			this.items = items;
		}
		public override ColorItem this[int position]
		{
			get
			{
				return items[position];
			}
		}

		public override int Count
		{
			get
			{
				return items.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];
			View view = convertView;
			if (view == null)
			{
				view = this.context.LayoutInflater.Inflate(Resource.Layout.listviewdemo, null);
			}

			view.FindViewById<TextView>(Resource.Id.textView1).Text = item.ColorName;
			view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Code;
			view.FindViewById<ImageView>(Resource.Id.imageView1).SetBackgroundColor(item.Color);
			return view;
		}
	}
}
