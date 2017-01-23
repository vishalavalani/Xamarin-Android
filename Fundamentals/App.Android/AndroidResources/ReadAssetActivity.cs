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
using Android.Content.Res;
using System.IO;

namespace AppAndroid.AndroidResources
{
    [Activity(Label = "ReadAsset")]
    public class ReadAssetActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.readasset);

            TextView txtData = FindViewById<TextView>(Resource.Id.txtData);
            Button btnFetchData = FindViewById<Button>(Resource.Id.btnFetchData);
            btnFetchData.Click += (object sender, EventArgs e) =>
            {
                AssetManager assets = this.Assets;
                string content = string.Empty;
                using (StreamReader sr = new StreamReader(assets.Open("read_test.txt")))
                {
                    content = sr.ReadToEnd();
                }
                txtData.Text = content;
            };

            // Create your application here
            
        }


    }
}