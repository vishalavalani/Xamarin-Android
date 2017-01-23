package md5a9553758071e76dc0a0fd3596da34bdd;


public class OrderActivity_UpmaFragment
	extends android.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Naivedyam.Droid.OrderActivity+UpmaFragment, Naivedyam.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", OrderActivity_UpmaFragment.class, __md_methods);
	}


	public OrderActivity_UpmaFragment () throws java.lang.Throwable
	{
		super ();
		if (getClass () == OrderActivity_UpmaFragment.class)
			mono.android.TypeManager.Activate ("Naivedyam.Droid.OrderActivity+UpmaFragment, Naivedyam.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);

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
