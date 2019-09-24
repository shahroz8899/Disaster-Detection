using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DisasterDetector
{
    [Activity(Label = "Disaster Detector", MainLauncher = false, Icon = "@drawable/button")]
    public class BlueToothListActivity : Activity
    {
        BluetoothConnection conn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.listBlueTooth);

            conn = new BluetoothConnection();
            conn.getAdapter();
            conn.thisAdapter.StartDiscovery();
            var Listview11 = FindViewById<ListView>(Resource.Id.listView1);
            Listview11.Adapter = new HomeScreenAdapter(this, conn.GetBlueToothDevices());
            Listview11.FastScrollEnabled = true;
            Listview11.ItemClick += Listview11_ItemClick;
            // Create your application here
        }

        private void Listview11_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string name = conn.GetBlueToothDevices()[e.Position].AdapterName;
            var activity2 = new Intent(this, typeof(MainActivity));
            activity2.PutExtra("adapter", name);
            StartActivity(activity2);
        }
    }

   
}






