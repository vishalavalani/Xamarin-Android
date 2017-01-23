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

namespace Naivedyam.Droid
{
    [Activity(Label = "About Naivedyam")]
    public class AboutActivity : Activity
    {
        TextView textViewPhone;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.about);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            textViewPhone = FindViewById<TextView>(Resource.Id.textViewPhone);
            textViewPhone.Click += (object sender, EventArgs e) =>
            {
                var uri = Android.Net.Uri.Parse("tel:" + textViewPhone.Text);
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
            };
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}