using Android.OS;
using Android.Views;
using System;

namespace TrainningXamarin.Fragments
{
    public class HomeFragment : BaseFragment
    {

        public static string TAG = "HomeFragment";
        public HomeFragment(MainActivity activity)
        {
            InitFragment(activity);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //HasOptionsMenu = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return inflater.Inflate(Resource.Layout.HomeLayout, container, false);
        }

        public override void ReceiveHandler(Bundle data)
        {
            throw new NotImplementedException();
        }
    }
}