package md5e968c13a35d5611432954ae549b2adf8;


public class AllRecipientsView
	extends md5c293e307133ee8f46151deed2480c6a8.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("MyTrains.Droid.Views.AllRecipientsView, MyTrains.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AllRecipientsView.class, __md_methods);
	}


	public AllRecipientsView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AllRecipientsView.class)
			mono.android.TypeManager.Activate ("MyTrains.Droid.Views.AllRecipientsView, MyTrains.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
