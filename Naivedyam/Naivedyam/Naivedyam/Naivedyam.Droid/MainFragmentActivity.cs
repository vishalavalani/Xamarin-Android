using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Views.InputMethods;

namespace Naivedyam.Droid
{
    public class MainFragmentActivity : Fragment
    {
        Button btnPlaceOrder;
        Button btnViewCart;
        Button btnTakePic;
        Button btnGoToNaivedyam;
        Button btnAboutNaivedyam;
        public override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //this code is to load action bar icon
            //this.ActionBar.SetLogo(Resource.Drawable.naivedyamlogo);
            //this.ActionBar.SetDisplayUseLogoEnabled(true);
            //this.ActionBar.SetDisplayShowHomeEnabled(true);
            // Set our view from the "main" layout resource
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ViewGroup root = (ViewGroup)inflater.Inflate(Resource.Layout.Main, null);
            btnPlaceOrder = root.FindViewById<Button>(Resource.Id.btnPlaceOrder);
            btnViewCart = root.FindViewById<Button>(Resource.Id.btnViewCart);
            btnTakePic = root.FindViewById<Button>(Resource.Id.btnTakePic);
            btnGoToNaivedyam = root.FindViewById<Button>(Resource.Id.btnGoToNaivedyam);
            btnAboutNaivedyam = root.FindViewById<Button>(Resource.Id.btnAboutNaivedyam);

            btnPlaceOrder.Click += BtnPlaceOrder_Click;
            btnViewCart.Click += BtnViewCart_Click;
            btnGoToNaivedyam.Click += BtnbtnGoToNaivedyam_Click;
            btnTakePic.Click += BtnTakePic_Click;
            btnAboutNaivedyam.Click += BtnAboutNaivedyam_Click;
            return root;
        }

        private void BtnAboutNaivedyam_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this.Activity, typeof(AboutActivity));
            StartActivity(i);
        }

        private void BtnTakePic_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this.Activity, typeof(TakePicActivity));
            StartActivity(i);
        }

        private void BtnbtnGoToNaivedyam_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this.Activity, typeof(GoToStoreActivity));
            StartActivity(i);
        }

        private void BtnViewCart_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this.Activity, typeof(ViewCartActivity));
            StartActivity(i);
        }

        private void BtnPlaceOrder_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this.Activity, typeof(OrderActivity));
            StartActivity(i);
        }
    }
}