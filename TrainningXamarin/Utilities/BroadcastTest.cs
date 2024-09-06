using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NhatMinhQCI.Utilities
{
    internal class BroadcastTest : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            String value = intent.GetStringExtra("data");
            Console.WriteLine("______________: "+value);
        }
    }
}