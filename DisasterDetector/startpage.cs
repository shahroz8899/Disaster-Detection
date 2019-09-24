using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using IO.Netopen.Hotbitmapgg.Library.View;
using static IO.Netopen.Hotbitmapgg.Library.View.RingProgressBar;

namespace DisasterDetector
{
    [Activity( MainLauncher = true, Icon = "@drawable/button")]
    public class startpage : BlueToothListActivity, IOnProgressListener
    {  
        RingProgressBar ringProgressBar1, ringProgressBar2;
        int progress = 0;

        public void ProgressToComplete()
        {
            RunOnUiThread(() =>
            {
                
                Intent activity3 = new Intent(this, typeof(BlueToothListActivity));

                StartActivity(activity3);
                Finish();

            });



            
        }

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.startpage);

            

            ringProgressBar1 = FindViewById<RingProgressBar>(Resource.Id.progress_bar_1);
            ringProgressBar2 = FindViewById<RingProgressBar>(Resource.Id.progress_bar_2);

            ringProgressBar1.SetOnProgressListener(this);

            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    if (progress < 100)
                    {
                        Thread.Sleep(100);
                        progress++;
                        ringProgressBar1.Progress = ringProgressBar2.Progress = progress;

                    }

                }



            }
            );

            // Create your application here
        }



        


    }

   
}