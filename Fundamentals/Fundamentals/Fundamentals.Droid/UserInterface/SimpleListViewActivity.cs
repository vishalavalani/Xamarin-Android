
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
	[Activity(Label = "SimpleListViewActivity")]
	public class SimpleListViewActivity : ListActivity
	{
		string[] objects = {"Vishal","Manan","Neeta","Amisha","Nishita" };
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, objects);

		}

		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			base.OnListItemClick(l, v, position, id);
			Toast.MakeText(this, objects[position], ToastLength.Short).Show();
		}
	}
}
