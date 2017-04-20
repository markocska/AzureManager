package md550670e6e4a5635adbcb6f88e942ff6bd;


public class ActivityBaseEx
	extends md53c08667da5270c0978fac10eaa6f71aa.ActivityBase
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Flowers.Helpers.ActivityBaseEx, Flowers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ActivityBaseEx.class, __md_methods);
	}


	public ActivityBaseEx () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ActivityBaseEx.class)
			mono.android.TypeManager.Activate ("Flowers.Helpers.ActivityBaseEx, Flowers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
