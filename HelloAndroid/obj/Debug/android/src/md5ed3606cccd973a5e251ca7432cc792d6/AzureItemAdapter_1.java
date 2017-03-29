package md5ed3606cccd973a5e251ca7432cc792d6;


public abstract class AzureItemAdapter_1
	extends android.support.v7.widget.RecyclerView.Adapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getItemCount:()I:GetGetItemCountHandler\n" +
			"";
		mono.android.Runtime.register ("HelloAndroid.Adapters.AzureItemAdapter`1, HelloAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AzureItemAdapter_1.class, __md_methods);
	}


	public AzureItemAdapter_1 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AzureItemAdapter_1.class)
			mono.android.TypeManager.Activate ("HelloAndroid.Adapters.AzureItemAdapter`1, HelloAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public int getItemCount ()
	{
		return n_getItemCount ();
	}

	private native int n_getItemCount ();

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
