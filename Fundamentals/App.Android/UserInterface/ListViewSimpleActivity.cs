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
using AppAndroid.AndroidResources;
using AppAndroid.AppFundamentals;

namespace AppAndroid.UserInterface
{
    [Activity(Label = "Demo App")]
    public class ListViewSimpleActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string[] activities = new string[] {
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

            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, activities);

        }
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            //base.OnListItemClick(l, v, position, id);
            if (position == 0)
            {
                StartActivity(new Intent(this, typeof(AutoCompleteActivity)));
            }
            if (position == 1)
            {
                StartActivity(new Intent(this, typeof(CardViewActivity)));
            }
            if (position == 2)
            {
                StartActivity(new Intent(this, typeof(DatePickerActivity)));
            }
            if (position == 3)
            {
                StartActivity(new Intent(this, typeof(FormDemoActivity)));
            }
            if (position == 4)
            {
                StartActivity(new Intent(this, typeof(GalleryActivity)));
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
                StartActivity(new Intent(this, typeof(LinearLayoutActivity)));
            }
            if (position == 8)
            {
                StartActivity(new Intent(this, typeof(ListViewCustomActivity)));
            }
            if (position == 9)
            {
                StartActivity(new Intent(this, typeof(ListViewMainActivity)));
            }
            if (position == 10)
            {
                StartActivity(new Intent(this, typeof(NavigationBarActivity)));
            }
            if (position == 11)
            {
                StartActivity(new Intent(this, typeof(PopupMenuActivity)));
            }
            if (position == 12)
            {
                StartActivity(new Intent(this, typeof(RecyclerActivity)));
            }
            if (position == 13)
            {
                StartActivity(new Intent(this, typeof(RelativeLayoutActivity)));
            }
            if (position == 14)
            {
                StartActivity(new Intent(this, typeof(TabDemoActivity)));
            }
            if (position == 15)
            {
                StartActivity(new Intent(this, typeof(TableLayoutActivity)));
            }
            if (position == 16)
            {
                StartActivity(new Intent(this, typeof(LanguageActivity)));
            }
            if (position == 17)
            {
                StartActivity(new Intent(this, typeof(OrientationActivity)));
            }
            if (position == 18)
            {
                StartActivity(new Intent(this, typeof(ReadAssetActivity)));
            }
            if (position == 19)
            {
                StartActivity(new Intent(this, typeof(LifecycleActivityA)));
            }
            if (position == 20)
            {
                StartActivity(new Intent(this, typeof(RetainComplexDataActivity)));
            }
            if (position == 21)
            {
                StartActivity(new Intent(this, typeof(RotationActivity)));
            }
            if (position == 22)
            {
                StartActivity(new Intent(this, typeof(SaveStateActivity)));
            }
        }
    }
}