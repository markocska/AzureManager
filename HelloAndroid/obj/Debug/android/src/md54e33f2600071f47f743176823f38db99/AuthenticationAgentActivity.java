package md54e33f2600071f47f743176823f38db99;


public class AuthenticationAgentActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_finish:()V:GetFinishHandler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationAgentActivity, Microsoft.IdentityModel.Clients.ActiveDirectory.Platform, Version=3.13.8.999, Culture=neutral, PublicKeyToken=31bf3856ad364e35", AuthenticationAgentActivity.class, __md_methods);
	}


	public AuthenticationAgentActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AuthenticationAgentActivity.class)
			mono.android.TypeManager.Activate ("Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationAgentActivity, Microsoft.IdentityModel.Clients.ActiveDirectory.Platform, Version=3.13.8.999, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void finish ()
	{
		n_finish ();
	}

	private native void n_finish ();

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
