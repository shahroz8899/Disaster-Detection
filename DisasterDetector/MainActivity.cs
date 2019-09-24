using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Widget;
using Android.OS;
using Android.Bluetooth;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Android.Telephony;
using System.Text;
using Android.Locations;
using Android.Util;
using System.Collections.Generic;

namespace DisasterDetector
{
    [Activity(Label = "Disaster Detector", MainLauncher = false, Icon = "@drawable/button")]
    public class MainActivity : Activity, ILocationListener
    {

        BluetoothConnection myConnection = new BluetoothConnection();
        private Stream outStream = null;
        private Java.Lang.String dataToSend;
        LocationManager locMgr;
        string tag = "MainActivity";
        protected Handler _handler;
        TextView latitude;
        TextView longitude;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);


            latitude = FindViewById<TextView>(Resource.Id.latitude);
            longitude = FindViewById<TextView>(Resource.Id.longitude);

            string name = Intent.GetStringExtra("adapter");
            BluetoothSocket _socket = null;
            try
            {

                //listenThread.Start();

                myConnection = new BluetoothConnection();
                myConnection.getAdapter();
                myConnection.thisAdapter.StartDiscovery();
                myConnection.getDevice(name);
                myConnection.thisDevice.SetPairingConfirmation(false);
                myConnection.thisDevice.SetPairingConfirmation(true);
                myConnection.thisDevice.CreateBond();


            }
            catch (Exception)
            {
            }


            myConnection.thisAdapter.CancelDiscovery();
            _socket = myConnection.thisDevice.CreateRfcommSocketToServiceRecord(Java.Util.UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
            myConnection.thisSocket = _socket;


            try
            {



                myConnection.thisSocket.Connect();


                beginListenForData();
                Toast.MakeText(this, "Successfully Connected with" + name, ToastLength.Long).Show();


            }
            catch (Exception)
            {

            }


        }

        private void Btntest8_Click(object sender, EventArgs e)
        {
            dataToSend = new Java.Lang.String("D");
            writeData(dataToSend);
        }



        public void beginListenForData()
        {
            EditText txtresponse = FindViewById<EditText>(Resource.Id.EditText1);
            EditText PhoneNumber = FindViewById<EditText>(Resource.Id.PhoneNumber);
            EditText Name = FindViewById<EditText>(Resource.Id.Name);

            Task.Factory.StartNew(() =>
            {

                int bufferSize = 1024;
                byte[] buffer = new byte[bufferSize];
                ASCIIEncoding encoder = new ASCIIEncoding();
                while (true)
                {
                    string response = string.Empty;
                    string msg = string.Empty;
                    int bytesRead = myConnection.thisSocket.InputStream.Read(buffer, 0, buffer.Length);

                    if (bytesRead != 0)
                    {
                        response = encoder.GetString(buffer, 0, bytesRead);

                        RunOnUiThread(() =>
                        {
                            if (response.Contains(";"))
                            {

                                SmsManager.Default.SendTextMessage(PhoneNumber.Text, null," Alert!"+" "+ Name.Text +" " + txtresponse.Text + "http//maps.google.com/?q=" + latitude.Text + "," + longitude.Text, null, null);
                                response = "";
                                msg = "";
                                txtresponse.Text = "";
                            }
                            else
                            {
                                txtresponse.Text = txtresponse.Text + response.ToString();
                            }

                        });
                    }
                }
            });
        }



        private void writeData(Java.Lang.String data)
        {
            try
            {
                outStream = myConnection.thisSocket.OutputStream;
            }
            catch (System.Exception)
            {

                Toast.MakeText(this, "Error", ToastLength.Short).Show();
            }

            Java.Lang.String message = data;

            byte[] msgBuffer = message.GetBytes();


            try
            {
                outStream.Write(msgBuffer, 0, msgBuffer.Length);
            }
            catch (System.Exception e)
            {

                Toast.MakeText(this, "Error 1", ToastLength.Short).Show();
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(tag, "OnResume called");

            // initialize location manager

            locMgr = GetSystemService(Context.LocationService) as LocationManager;
            if (locMgr.AllProviders.Contains(LocationManager.NetworkProvider)
                    && locMgr.IsProviderEnabled(LocationManager.NetworkProvider))
            {
                locMgr.RequestLocationUpdates(LocationManager.NetworkProvider, 2000, 1, this);
            }
            else
            {
                Toast.MakeText(this, "The Network Provider does not exist or is not enabled!", ToastLength.Long).Show();
            }

        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug(tag, "OnStart called");
        }

        protected override void OnPause()
        {
            base.OnPause();
            locMgr.RemoveUpdates(this);
            Log.Debug(tag, "Location updates paused because application is entering the background");
        }

        protected override void OnStop()
        {
            base.OnStop();
            Log.Debug(tag, "OnStop called");
        }

        public void OnLocationChanged(Location location)
        {
            Log.Debug(tag, "Location changed");
            latitude.Text = location.Latitude.ToString();
            longitude.Text = location.Longitude.ToString();

        }

        public void OnProviderDisabled(string provider)
        {
            Log.Debug(tag, provider + " disabled by user");
        }

        public void OnProviderEnabled(string provider)
        {
            Log.Debug(tag, provider + " enabled by user");
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            Log.Debug(tag, provider + " availability has changed to " + status.ToString());
        }
    }




    public class BluetoothConnection
    {

        public void getAdapter() { this.thisAdapter = BluetoothAdapter.DefaultAdapter; }
        public void getDevice(string device) { this.thisDevice = (from bd in this.thisAdapter.BondedDevices where bd.Name == device select bd).FirstOrDefault(); }

        public List<BlAdapter> GetBlueToothDevices()
        {
            List<BlAdapter> bladp = new List<BlAdapter>();

            foreach (var bl in thisAdapter.BondedDevices)
            {
                bladp.Add(new BlAdapter { AdapterName = bl.Name, MacAddress = bl.Address });
            }


            return bladp;
        }
        public BluetoothAdapter thisAdapter { get; set; }
        public BluetoothDevice thisDevice { get; set; }


        public BluetoothSocket thisSocket { get; set; }



    }


    public class clsPath
    {
        private int iD;
        private double longi;
        private double lat;
        private string area;
        private bool isread;

        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public double Longi
        {
            get
            {
                return longi;
            }

            set
            {
                longi = value;
            }
        }

        public double Lat
        {
            get
            {
                return lat;
            }

            set
            {
                lat = value;
            }
        }

        public string Area
        {
            get
            {
                return area;
            }

            set
            {
                area = value;
            }
        }

        public bool Isread
        {
            get
            {
                return isread;
            }

            set
            {
                isread = value;
            }
        }
    }



}

