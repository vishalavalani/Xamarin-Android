
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

namespace Fundamentals.Droid
{
	[Activity(Label = "FormsDemoActivity")]
	public class FormsDemoActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.formelements);
			// Create your application here

			CheckBox chkBox = FindViewById<CheckBox>(Resource.Id.checkBox1);
			Button button = FindViewById<Button>(Resource.Id.button);
			EditText edittext = FindViewById<EditText>(Resource.Id.edittext);

			chkBox.Click += (object sender, EventArgs e) =>
		   {
			   if (chkBox.Checked)
			   {
				   Toast.MakeText(this, "Selected", ToastLength.Long);

				   var callDialog = new AlertDialog.Builder(this);
				   callDialog.SetMessage("Checked");
				   callDialog.SetPositiveButton("Ok", delegate { });
				   callDialog.SetNegativeButton("Cancel", delegate { });
				   callDialog.Show();
			   }
			   else
			   {
				   Toast.MakeText(this, "Not Selected", ToastLength.Long);
				   var callDialog = new AlertDialog.Builder(this);
				   callDialog.SetMessage("Not Checked");
				   callDialog.SetPositiveButton("Ok", delegate { });
				   callDialog.SetNegativeButton("Cancel", delegate { });
				   callDialog.Show();
			   }
		   };

			button.Click += (object sender1, EventArgs e1) =>
			 {
				 Toast.MakeText(this, "Beep Boop", ToastLength.Short).Show();
			 };

			RadioButton radio_red = FindViewById<RadioButton>(Resource.Id.radio_red);
			RadioButton radio_blue = FindViewById<RadioButton>(Resource.Id.radio_blue);

			radio_red.Click += RadioButtonClick;
			radio_blue.Click += RadioButtonClick;

			RatingBar ratingbar = FindViewById<RatingBar>(Resource.Id.ratingbar);

			ratingbar.RatingBarChange += (o3, e3) =>
			{
				Toast.MakeText(this, "New Rating: " + ratingbar.Rating.ToString(), ToastLength.Short).Show();
			};

			ToggleButton togglebutton = FindViewById<ToggleButton>(Resource.Id.togglebutton);

			togglebutton.Click += (o4, e4) =>
			{
				// Perform action on clicks
				if (togglebutton.Checked)
					Toast.MakeText(this, "Checked", ToastLength.Short).Show();
				else
					Toast.MakeText(this, "Not checked", ToastLength.Short).Show();
			};

			Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

			var scaleNames = new List<string>() { "Vishal", "Amisha" };

			var adapter = new ArrayAdapter<string>(
				this, Android.Resource.Layout.SimpleSpinnerItem, scaleNames);

			adapter.SetDropDownViewResource
				(Android.Resource.Layout.SimpleSpinnerDropDownItem);

			spinner.Adapter = adapter;
		}

		private void RadioButtonClick(object sender, EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;
			Toast.MakeText(this, rb.Text, ToastLength.Short).Show();
		}
	}
}
