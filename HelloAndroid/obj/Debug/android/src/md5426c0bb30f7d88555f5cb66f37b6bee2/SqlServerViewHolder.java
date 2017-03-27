package md5426c0bb30f7d88555f5cb66f37b6bee2;


public class SqlServerViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("HelloAndroid.ViewHolders.SqlServerViewHolder, HelloAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SqlServerViewHolder.class, __md_methods);
	}


	public SqlServerViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == SqlServerViewHolder.class)
			mono.android.TypeManager.Activate ("HelloAndroid.ViewHolders.SqlServerViewHolder, HelloAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
