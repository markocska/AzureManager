package md5323d6593185735df52aaa8e5de13dcd2;


public class AddCommentActivity
	extends md550670e6e4a5635adbcb6f88e942ff6bd.ActivityBaseEx
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Flowers.AddCommentActivity, Flowers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AddCommentActivity.class, __md_methods);
	}


	public AddCommentActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AddCommentActivity.class)
			mono.android.TypeManager.Activate ("Flowers.AddCommentActivity, Flowers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
