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
    public class HomeScreenAdapter : BaseAdapter<BlAdapter>
    {
        List<BlAdapter> items;
        Activity context;
        public HomeScreenAdapter(Activity context, List<BlAdapter> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override BlAdapter this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.ListView, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.AdapterName;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = item.MacAddress;


            return view;
        }
    }

    public class BlAdapter
    {
        public string AdapterName { get; set; }
        public string MacAddress { get; set; }
    }
}