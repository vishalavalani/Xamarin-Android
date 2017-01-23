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
using Android.Graphics;
using Java.IO;
using Android.Provider;
using Android.Content.PM;
using Naivedyam.Droid.Helpers;

namespace Naivedyam.Droid
{
    [Activity(Label = "Take Picture")]
    public class TakePicActivity : Activity
    {
        ImageView imageViewPicture;
        Button btnLaunchCamera;
        Button btnSubmitPicture;
        Java.IO.File _file;
        Java.IO.File _dir;
        Bitmap bitmap;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.takepic);
            // Create your application here
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            imageViewPicture = FindViewById<ImageView>(Resource.Id.imageViewPicture);
            btnLaunchCamera = FindViewById<Button>(Resource.Id.btnLaunchCamera);
            btnSubmitPicture = FindViewById<Button>(Resource.Id.btnSubmitPicture);

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();
                btnLaunchCamera.Click += BtnLaunchCamera_Click;
                btnSubmitPicture.Click += BtnSubmitPicture_Click;
            }
        }

        private void CreateDirectoryForPictures()
        {
            _dir = new File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "NaivedyamPics");
            if (!_dir.Exists())
            {
                _dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void BtnSubmitPicture_Click(object sender, EventArgs e)
        {
            imageViewPicture.SetImageDrawable(null);
            Toast.MakeText(this, "Thanks for submitting picture!", ToastLength.Short).Show();
            this.Finish();
        }

        private void BtnLaunchCamera_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            _file = new File(_dir, String.Format("naivedyam_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_file));
            StartActivityForResult(intent, 0);
        }




        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (Android.App.Result.Canceled == resultCode)
                return;

            if (resultCode == Android.App.Result.FirstUser || resultCode == Android.App.Result.Ok)
            {
                // Make it available in the gallery

                Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                Android.Net.Uri contentUri = Android.Net.Uri.FromFile(_file);
                mediaScanIntent.SetData(contentUri);
                SendBroadcast(mediaScanIntent);

                // Display in ImageView. We will resize the bitmap to fit the display.
                // Loading the full sized image will consume to much memory
                // and cause the application to crash.

                int height = Resources.DisplayMetrics.HeightPixels;
                int width = imageViewPicture.Height;
                bitmap = _file.Path.LoadAndResizeBitmap(width, height);
                if (bitmap != null)
                {
                    imageViewPicture.SetImageBitmap(bitmap);
                    bitmap = null;
                }

                // Dispose of the Java side bitmap.
                GC.Collect();
            }
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