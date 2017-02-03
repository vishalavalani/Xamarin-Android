
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

namespace Fundamentals.Droid
{
	[Activity(Label = "ListViewCustomActivity")]
	public class ListViewCustomActivity : Activity
	{
		ListView listview;
		List<ColorItem> colorItems = new List<ColorItem>();

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.listviewmain);
			// Create your application here
			listview = FindViewById<ListView>(Resource.Id.myListView1);
			colorItems.Add(new ColorItem()
			{
				Color = Android.Graphics.Color.DarkRed,
				ColorName = "Dark Red",
				Code = "8B0000"
			});
			colorItems.Add(new ColorItem()
			{
				Color = Android.Graphics.Color.SlateBlue,
				ColorName = "Slate Blue",
				Code = "6A5ACD"
			});
			colorItems.Add(new ColorItem()
			{
				Color = Android.Graphics.Color.ForestGreen,
				ColorName = "Forest Green",
				Code = "228B22"
			});

			listview.Adapter = new ColorAdapter(this, colorItems);
		}
	}

	public class ColorItem
	{
		public string ColorName { get; set; }
		public string Code { get; set; }
		public Android.Graphics.Color Color { get; set; }
	}
}
