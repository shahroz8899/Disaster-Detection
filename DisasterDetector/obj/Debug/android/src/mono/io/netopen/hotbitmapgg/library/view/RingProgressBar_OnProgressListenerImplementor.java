package mono.io.netopen.hotbitmapgg.library.view;


public class RingProgressBar_OnProgressListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		io.netopen.hotbitmapgg.library.view.RingProgressBar.OnProgressListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_progressToComplete:()V:GetProgressToCompleteHandler:IO.Netopen.Hotbitmapgg.Library.View.RingProgressBar/IOnProgressListenerInvoker, RingProgressBar\n" +
			"";
		mono.android.Runtime.register ("IO.Netopen.Hotbitmapgg.Library.View.RingProgressBar+IOnProgressListenerImplementor, RingProgressBar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", RingProgressBar_OnProgressListenerImplementor.class, __md_methods);
	}


	public RingProgressBar_OnProgressListenerImplementor ()
	{
		super ();
		if (getClass () == RingProgressBar_OnProgressListenerImplementor.class)
			mono.android.TypeManager.Activate ("IO.Netopen.Hotbitmapgg.Library.View.RingProgressBar+IOnProgressListenerImplementor, RingProgressBar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


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
