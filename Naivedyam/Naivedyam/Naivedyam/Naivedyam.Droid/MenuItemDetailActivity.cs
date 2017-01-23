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
using Naivedyam.Droid.Models;
using Naivedyam.Droid.Data;
using Naivedyam.Droid.Base;

namespace Naivedyam.Droid
{
    [Activity(Label = "MenuItemDetailActivity")]
    public class MenuItemDetailActivity : ActivityBase
    {
        TextView textViewItemTitle;
        ImageView imageViewItemImage;
        TextView textViewItemDescription;
        TextView textViewItemPrice;
        EditText editTextItemCount;
        Button btnItemAddToCart;
        Button btnCancel;

        MenuItem item;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.menuitemdetail);

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            textViewItemTitle = FindViewById<TextView>(Resource.Id.textViewItemTitle);
            imageViewItemImage = FindViewById<ImageView>(Resource.Id.imageViewItemImage);
            textViewItemDescription = FindViewById<TextView>(Resource.Id.textViewItemDescription);
            textViewItemPrice = FindViewById<TextView>(Resource.Id.textViewItemPrice);
            editTextItemCount = FindViewById<EditText>(Resource.Id.editTextItemCount);
            btnItemAddToCart = FindViewById<Button>(Resource.Id.btnItemAddToCart);
            btnCancel = FindViewById<Button>(Resource.Id.btnCancel);

            btnCancel.Click += BtnCancel_Click;


            item = DataHelper.MenuItems.Where(d => d.MenuItemID == Convert.ToInt32(Intent.GetStringExtra("menuitemid"))).FirstOrDefault();
            this.ActionBar.Title = item.Name + " details";
            textViewItemTitle.Text = item.Name;
            textViewItemDescription.Text = item.Description;
            textViewItemPrice.Text = "Rs. " + item.Price.ToString();
            imageViewItemImage.SetImageResource(item.ImageID);

            btnItemAddToCart.Click += (object sender, EventArgs e) =>
            {
                if (String.IsNullOrEmpty(editTextItemCount.Text.Trim()))
                {
                    Toast.MakeText(this, "Please enter items to order", ToastLength.Short).Show();
                }
                else
                {
                    DataHelper.CartItems.Add(new Cart() { MenuItemID = item.MenuItemID, Quantity = Convert.ToInt32(editTextItemCount.Text.Trim()) });
                    Toast.MakeText(this, item.Name + " added to cart!", ToastLength.Short).Show();
                    this.Finish();
                }
            };
        }

        private void BtnItemAddToCart_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return base.OnCreateOptionsMenu(menu);
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