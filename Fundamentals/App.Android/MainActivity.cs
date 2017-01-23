using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using AppAndroid.AndroidResources;
using AppAndroid.AppFundamentals;
using AppAndroid.Services;
using AppAndroid.UserInterface;

namespace AppAndroid
{

    [Activity(Icon = "@drawable/icon",Theme = "@android:style/Theme.Material.Light")]
    public class MainActivity : Activity
    {
        static readonly List<String> phoneNumbers = new List<String>();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.Title = "First Screen";
            
            SetContentView(Resource.Layout.Main);
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.editPhoneNumberText);
            Button btnTranslate = FindViewById<Button>(Resource.Id.btnTranslate);
            Button btnCall = FindViewById<Button>(Resource.Id.btnCall);
            Button btnCallHistory = FindViewById<Button>(Resource.Id.btnCallHistory);
            Button btnOrientation = FindViewById<Button>(Resource.Id.btnOrientation);

            btnOrientation.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(FormDemoActivity));
                StartActivity(intent);
            };
            btnCall.Enabled = false;
            string translatedNumber = string.Empty;

            btnCallHistory.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(CallHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };

            btnTranslate.Click += (object sender, EventArgs e) =>
            {
                translatedNumber = Helpers.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                if (String.IsNullOrWhiteSpace(translatedNumber))
                {
                    btnCall.Text = "Call";
                    btnCall.Enabled = false;
                }
                else
                {
                    btnCall.Text = "Call " + translatedNumber;
                    btnCall.Enabled = true;
                }
            };

            btnCall.Click += (object sender, EventArgs e) =>
            {
                var callDialog = new AlertDialog.Builder(this);
                callDialog.SetMessage("Call " + translatedNumber + "?");
                callDialog.SetNeutralButton("Call", delegate
                {
                    phoneNumbers.Add(translatedNumber);
                    btnCallHistory.Enabled = true;
                    var callIntent = new Intent(Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
                    StartActivity(callIntent);
                });

                callDialog.SetNegativeButton("Cancel", delegate { });
                callDialog.Show();
            };
        }
    }
}

