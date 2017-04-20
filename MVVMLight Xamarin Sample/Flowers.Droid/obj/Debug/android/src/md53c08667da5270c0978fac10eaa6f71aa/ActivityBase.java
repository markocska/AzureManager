package md53c08667da5270c0978fac10eaa6f71aa;


public class ActivityBase
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"n_onPause:()V:GetOnPauseHandler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"";
		mono.android.Runtime.register ("GalaSoft.MvvmLight.Views.ActivityBase, GalaSoft.MvvmLight.Platform, Version=5.1.0.21519, Culture=neutral, PublicKeyToken=null", ActivityBase.class, __md_methods);
	}


	public ActivityBase () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ActivityBase.class)
			mono.android.TypeManager.Activate ("GalaSoft.MvvmLight.Views.ActivityBase, GalaSoft.MvvmLight.Platform, Version=5.1.0.21519, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();


	public void onPause ()
	{
		n_onPause ();
	}

	private native void n_onPause ();


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();

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
