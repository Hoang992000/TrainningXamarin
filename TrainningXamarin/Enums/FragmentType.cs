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

namespace NhatMinhQCI.Enums
{
    public enum FragmentType
    {
        None = 0,
        Home = 1,
        Inventory = 2,
        Product = 3,
        AddProduct = 4,
        AddPurchaseOrder = 5,
        ScanBox = 6,
        Login = 7,
        RemoveCarton =8
    }
}