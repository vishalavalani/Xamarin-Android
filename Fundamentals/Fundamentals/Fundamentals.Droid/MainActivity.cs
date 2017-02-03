using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Fundamentals.Droid.UserInterface;

namespace Fundamentals.Droid
{
	[Activity(Label = "Fundamentals", MainLauncher = true)]
	public class MainActivity : ListActivity
	{
		string[] activities = new string[] {
				"Life cycle",
				"Rotation",
				"Orientation View",
				"Language",
				"LinearLayout",
				"GridLayout",
				"GridViewLayout",
				"RelativeLayout",
				"Simple ListView",
				"Custom ListView",
				"Forms Demo",

				"AutoComplete",
				"CardView",
				"DatePicker",
				"FormDemo",
				"Gallery",
				"GridLayout",
				"GridView",
				"LinearLayout",
				"ListViewCustom",
				"ListViewMain",
				"NavigationBar",
				"PopupMenu",
				"Recycler",
				"RelativeLayout",
				"TabDemo",
				"TableLayout",
				"Language",
				"Orientation",
				"ReadAsset",
				"Lifecycle",
				"Recycler",
				"RetainComplexData",
				"Rotation",
				"SaveState"
			};

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			//SetContentView(Resource.Layout.Main);

			this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, activities);

		}

		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			base.OnListItemClick(l, v, position, id);
			if (position == 0)
			{
				StartActivity(new Intent(this, typeof(LifeCycleActivityA))); ;
			}
			if (position == 1)
			{
				StartActivity(new Intent(this, typeof(RotationActivity)));
			}
			if (position == 2)
			{
				StartActivity(new Intent(this, typeof(OrientationActivity)));
			}
			if (position == 3)
			{
				StartActivity(new Intent(this, typeof(LanguageActivity)));
			}
			if (position == 4)
			{
				StartActivity(new Intent(this, typeof(LinearLayoutActivity)));
			}
			if (position == 5)
			{
				StartActivity(new Intent(this, typeof(GridLayoutActivity)));
			}
			if (position == 6)
			{
				StartActivity(new Intent(this, typeof(GridViewActivity)));
			}
			if (position == 7)
			{
				StartActivity(new Intent(this, typeof(RelativeLayoutActivity)));
			}
			if (position == 8)
			{
				StartActivity(new Intent(this, typeof(SimpleListViewActivity)));
			}
			if (position == 9)
			{
				StartActivity(new Intent(this, typeof(ListViewCustomActivity)));
			}
			if (position == 10)
			{
				StartActivity(new Intent(this, typeof(FormsDemoActivity)));
			}
		}
	}
}


