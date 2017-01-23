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
    [Activity(Label = "PopupMenuActivity")]
    public class PopupMenuActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.popupmenudemo);
            // Create your application here
            Button showPopupMenu = FindViewById<Button>(Resource.Id.btnPopupmenu);
            showPopupMenu.Click += (s, arg) =>
            {
                PopupMenu menu = new PopupMenu(this, showPopupMenu);
                menu.Inflate(Resource.Menu.popup_menu);

                menu.MenuItemClick += (s1, arg1) =>
                {
                    Console.WriteLine("{0} selected", arg1.Item.TitleFormatted);
                };

                menu.DismissEvent += (s2, arg2) =>
                {
                    Console.WriteLine("menu dismissed");
                };
                menu.Show();
            };


        }
    }
}