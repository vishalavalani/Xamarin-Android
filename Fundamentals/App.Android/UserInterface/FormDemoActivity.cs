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
    [Activity(Label = "FormDemoActivity")]
    public class FormDemoActivity : Activity
    {
        private TextView time_display;
        private Button pick_button;

        private int hour;
        private int minute;

        const int TIME_DIALOG_ID = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.formelements);
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

                button.Click += (object sender1, EventArgs e1) =>
                {
                    Toast.MakeText(this, "Beep Boop", ToastLength.Short).Show();
                };

                edittext.KeyPress += (object sender2, View.KeyEventArgs e2) =>
                {
                    e2.Handled = false;
                    if (e2.Event.Action == KeyEventActions.Down && e2.KeyCode == Keycode.Enter)
                    {
                        Toast.MakeText(this, edittext.Text, ToastLength.Short).Show();
                        e2.Handled = true;
                    }
                };

                RadioButton radio_red = FindViewById<RadioButton>(Resource.Id.radio_red);
                RadioButton radio_blue = FindViewById<RadioButton>(Resource.Id.radio_blue);

                radio_red.Click += RadioButtonClick;
                radio_blue.Click += RadioButtonClick;
            };

            RatingBar ratingbar = FindViewById<RatingBar>(Resource.Id.ratingbar);

            ratingbar.RatingBarChange += (o3, e3) => {
                Toast.MakeText(this, "New Rating: " + ratingbar.Rating.ToString(), ToastLength.Short).Show();
            };
            ToggleButton togglebutton = FindViewById<ToggleButton>(Resource.Id.togglebutton);

            togglebutton.Click += (o4, e4) => {
                // Perform action on clicks
                if (togglebutton.Checked)
                    Toast.MakeText(this, "Checked", ToastLength.Short).Show();
                else
                    Toast.MakeText(this, "Not checked", ToastLength.Short).Show();
            };

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.planets_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            // Capture our View elements
            time_display = FindViewById<TextView>(Resource.Id.timeDisplay);
            pick_button = FindViewById<Button>(Resource.Id.pickTime);

            // Add a click listener to the button
            pick_button.Click += (o, e) => ShowDialog(TIME_DIALOG_ID);

            // Get the current time
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;

            // Display the current date
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            string time = string.Format("{0}:{1}", hour, minute.ToString().PadLeft(2, '0'));
            time_display.Text = time;
        }

        private void TimePickerCallback(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            hour = e.HourOfDay;
            minute = e.Minute;
            UpdateDisplay();
        }

        protected override Dialog OnCreateDialog(int id)
        {
            if (id == TIME_DIALOG_ID)
                return new TimePickerDialog(this, TimePickerCallback, hour, minute, false);

            return null;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
        private void RadioButtonClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Toast.MakeText(this, rb.Text, ToastLength.Short).Show();
        }

    }
}