using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Fundamentals.Droid.UserInterface
{
    [Activity(Label = "RelativeLayoutActivity")]
    public class RelativeLayoutActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.relativelayout);

			var myeditText1 = this.FindViewById<EditText>(Resource.Id.myeditText1);
			var myButton1 = this.FindViewById<Button>(Resource.Id.myButton1);
			var textView1 = this.FindViewById<TextView>(Resource.Id.textView1);


			myButton1.Click += (sender, e) =>
			{
				Task.Factory.StartNew(() => {
					while (myeditText1.Text.Length > 0)
					{
						var letter = myeditText1.Text.Substring(0, 1);
						this.RunOnUiThread(() => {
							textView1.Text = textView1.Text + letter;
							myeditText1.Text = myeditText1.Text.Substring(1);
						});
						Thread.Sleep(1000);
					}
				});
			};
        }
    }
}