package md50132bde516d5ba0aa06c33108d511f84;


public class startpage
	extends md50132bde516d5ba0aa06c33108d511f84.BlueToothListActivity
	implements
		mono.android.IGCUserPeer,
		io.netopen.hotbitmapgg.library.view.RingProgressBar.OnProgressListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_progressToComplete:()V:GetProgressToCompleteHandler:IO.Netopen.Hotbitmapgg.Library.View.RingProgressBar/IOnProgressListenerInvoker, RingProgressBar\n" +
			"";
		mono.android.Runtime.register ("DisasterDetector.startpage, DisasterDetector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", startpage.class, __md_methods);
	}


	public startpage ()
	{
		super ();
		if (getClass () == startpage.class)
			mono.android.TypeManager.Activate ("DisasterDetector.startpage, DisasterDetector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void progressToComplete ()
	{
		n_progressToComplete ();
	}

	private native void n_progressToComplete ();

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
