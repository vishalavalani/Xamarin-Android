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
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace Naivedyam.Droid
{
    [Activity(Label = "Find Naivedyam")]
    public class GoToStoreActivity : Activity
    {
        private Button btnExternalMap;
        private FrameLayout frameLayoutMap;
        private MapFragment mapFragment;
        GoogleMap googleMap;
        LatLng naivedyamLocation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.gotostore);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
 
            frameLayoutMap = FindViewById<FrameLayout>(Resource.Id.frameLayoutMap);
            btnExternalMap = FindViewById<Button>(Resource.Id.btnExternalMap);
            naivedyamLocation = new LatLng(23.055193, 72.558500);
            CreateMapFragment();
            UpdateMapView();

            btnExternalMap.Text = "Open in Google Maps";
            btnExternalMap.Click += BtnExternalMap_Click;
        }

        private void BtnExternalMap_Click(object sender, EventArgs e)
        {
            var geoUri = Android.Net.Uri.Parse("geo:23.055193,72.558500");
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);
        }

        private void UpdateMapView()
        {
            var mapReadyCallback = new LocalMapReady();
            mapReadyCallback.MapReady += (object sender, EventArgs e) =>
            {
                googleMap = (sender as LocalMapReady).Map;
                if(googleMap != null)
                {
                    MarkerOptions markerOptions = new MarkerOptions();
                    markerOptions.SetPosition(naivedyamLocation);
                    markerOptions.SetTitle("Naivedyam");
                    googleMap.AddMarker(markerOptions);

                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(naivedyamLocation, 15);
                    googleMap.MoveCamera(cameraUpdate);
                }
            };

            mapFragment.GetMapAsync(mapReadyCallback);
        }

       
        private void CreateMapFragment()
        {
            mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
            if (mapFragment == null)
            {
                var googleOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fTrans =
                    FragmentManager.BeginTransaction();

                mapFragment = MapFragment.NewInstance(googleOptions);
                fTrans.Add(Resource.Id.frameLayoutMap, mapFragment, "map");
                fTrans.Commit();
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

        private class LocalMapReady : Java.Lang.Object, IOnMapReadyCallback
        {
            public GoogleMap Map { get; set; }
            public event EventHandler MapReady;
            public void OnMapReady(GoogleMap googleMap)
            {
                Map = googleMap;
                var handler = MapReady;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
    }


}