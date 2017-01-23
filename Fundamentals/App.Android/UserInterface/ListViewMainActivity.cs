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
    [Activity(Label = "ListViewMainActivity")]
    public class ListViewMainActivity : Activity
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
                if(view == null)
                {
                    view = this.context.LayoutInflater.Inflate(Resource.Layout.listitemdemo, null);
                }

                view.FindViewById<TextView>(Resource.Id.textView1).Text = item.ColorName;
                view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Code;
                view.FindViewById<ImageView>(Resource.Id.imageView1).SetBackgroundColor(item.Color);
                return view;
            }
        }

        public class ColorItem
        {
            public string ColorName { get; set; }
            public string Code { get; set; }
            public Android.Graphics.Color Color { get; set; }
        }
    }
}