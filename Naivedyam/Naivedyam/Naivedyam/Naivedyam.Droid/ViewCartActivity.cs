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
using Naivedyam.Droid.Adapters;
using Naivedyam.Droid.Models;
using Naivedyam.Droid.Data;

namespace Naivedyam.Droid
{
    [Activity(Label = "View Cart")]
    public class ViewCartActivity : Activity
    {
        ListView ListViewCartItems;
        //TextView textViewTotalPrice;
        Button btnSubmit;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.viewcart);

            // Create your application here
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            //textViewTotalPrice = FindViewById<TextView>(Resource.Id.textViewTotalPrice);
            ListViewCartItems = FindViewById<ListView>(Resource.Id.ListViewCartItems);

            var cartAdapter = new CartAdapter(this, DataHelper.CartItems);
            ListViewCartItems.Adapter = cartAdapter;

            cartAdapter.ItemRemoved += (object sender, EventArgs e) =>
            {
                btnSubmit.Text = "Total Price: Rs. " + CalculateTotalPrice() + " ->" + " Checkout";
            };
            btnSubmit = FindViewById<Button>(Resource.Id.btnSubmit);
            btnSubmit.Click += (object sender, EventArgs e) =>
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Are you sure you want to submit. Total Bill Amount is Rs. " + CalculateTotalPrice() +  " ?");
                alert.SetNeutralButton("Yes", delegate 
                {
                    Random rnd = new Random();
                    DataHelper.OrderNumber = rnd.Next(1, 100);
                    Toast.MakeText(this, "Order No: NAIV00" + DataHelper.OrderNumber + ". Thanks for using our app. We will serve you shortly!", ToastLength.Long).Show();
                    DataHelper.CartItems.Clear();
                    this.Finish();
                });

                alert.SetNegativeButton("No", delegate { });
                alert.Show();
            };
        }


        protected override void OnResume()
        {
            base.OnResume();
            btnSubmit.Text = "Total Price: Rs. " + CalculateTotalPrice() + " ->" + " Checkout";
        }
        int CalculateTotalPrice()
        {
            int totalPrice = 0;
            foreach (var cartitem in DataHelper.CartItems)
            {
                totalPrice += cartitem.Quantity * DataHelper.MenuItems.Where(d => d.MenuItemID == cartitem.MenuItemID).FirstOrDefault().Price;
            }
            return totalPrice;
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