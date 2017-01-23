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

namespace AppAndroid.UserInterface
{
    [Activity(Label = "ListViewCustomActivity")]
    public class ListViewCustomActivity : Activity
    {
        ListView listView;
        List<TableItem> tableItems = new List<TableItem>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.listviewcustom);
            // Create your application here
            listView = FindViewById<ListView>(Resource.Id.List);
            tableItems.Add(new TableItem { Heading = "Vegetables", SubHeading = "65 items", ImageResourceId = Resource.Drawable.sample_0 });
            tableItems.Add(new TableItem { Heading = "Fruits", SubHeading = "18 items", ImageResourceId = Resource.Drawable.sample_1 });
            tableItems.Add(new TableItem { Heading = "Flower Buds", SubHeading = "5 items", ImageResourceId = Resource.Drawable.sample_2 });
            tableItems.Add(new TableItem { Heading = "Legumes", SubHeading = "5 items", ImageResourceId = Resource.Drawable.sample_3 });
            tableItems.Add(new TableItem { Heading = "Bulbs", SubHeading = "6 items", ImageResourceId = Resource.Drawable.sample_4 });
            listView.Adapter = new HomeScreenAdapter(this, tableItems);
            listView.ItemClick += OnListItemClick;  // to be defined
        }

        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = tableItems[e.Position];
            Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();
        }

        public class HomeScreenAdapter : BaseAdapter<TableItem>
        {
            List<TableItem> items;
            Activity context;
            public HomeScreenAdapter(Activity context, List<TableItem> items)
                : base()
            {
                this.context = context;
                this.items = items;
            }
            public override long GetItemId(int position)
            {
                return position;
            }
            public override TableItem this[int position]
            {
                get { return items[position]; }
            }
            public override int Count
            {
                get { return items.Count; }
            }
            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var item = items[position];
                View view = convertView;
                if (view == null) // no view to re-use, create new
                    view = context.LayoutInflater.Inflate(Resource.Layout.listcustomcell, null);
                view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Heading;
                view.FindViewById<TextView>(Resource.Id.Text2).Text = item.SubHeading;
                view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
                return view;
            }
        }
        public class TableItem
        {
            public string Heading { get; set; }
            public string SubHeading { get; set; }
            public int ImageResourceId { get; set; }
        }
    }
}