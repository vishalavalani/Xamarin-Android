package md5a9553758071e76dc0a0fd3596da34bdd;


public class GoToStoreActivity_LocalMapReady
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.maps.OnMapReadyCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMapReady:(Lcom/google/android/gms/maps/GoogleMap;)V:GetOnMapReady_Lcom_google_android_gms_maps_GoogleMap_Handler:Android.Gms.Maps.IOnMapReadyCallbackInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"";
		mono.android.Runtime.register ("Naivedyam.Droid.GoToStoreActivity+LocalMapReady, Naivedyam.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GoToStoreActivity_LocalMapReady.class, __md_methods);
	}


	public GoToStoreActivity_LocalMapReady () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GoToStoreActivity_LocalMapReady.class)
			mono.android.TypeManager.Activate ("Naivedyam.Droid.GoToStoreActivity+LocalMapReady, Naivedyam.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onMapReady (com.google.android.gms.maps.GoogleMap p0)
	{
		n_onMapReady (p0);
	}

	private native void n_onMapReady (com.google.android.gms.maps.GoogleMap p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
