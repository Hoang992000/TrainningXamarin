using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using AndroidX.AppCompat.App;
using NhatMinhQCI.Components;
using NhatMinhQCI.Enums;
using System;
using TrainningXamarin.Fragments;

namespace TrainningXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.MaterialComponents.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static string TAG = "MainActivity";
        protected bool LoopFlag = false;
        private Handler handler;
        public static ContentResolver contentResolver;
        public bool IsLoggedIn = false;
        public LoadingProgress loadingProgress;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            handler = new Handler(Looper.MainLooper, new BaseHandler(this));
            loadingProgress = new LoadingProgress(this);
            SwitchFragment(FragmentType.Login);
            SetContentView(Resource.Layout.activity_main);
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
             (sender, cert, chain, sslPolicyErrors) => true;
            contentResolver = this.ContentResolver;

            //base.OnCreate(savedInstanceState);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            //// Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.activity_main);
        }

        [Obsolete]
        public override void OnBackPressed()
        {
            ShowToast("Disabled", false);
        }

        protected override void OnDestroy()
        {
            Log.Debug(TAG, "On Destroy");
            base.OnDestroy();
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(TAG, "On Resume");

            if (IsLoggedIn)
            {
                //CheckUserInfo();
            }
            //Task.Run(InitializeReader);
            //Log.Debug(TAG, "Open RFID and Close Barcode");
        }

        //private async void CheckUserInfo()
        //{
        //    //try
        //    //{
        //    //    CurrentUser = await userRepository.GetUserInfo();
        //    //    Log.Debug(TAG, CurrentUser.UserName);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    if (ex.Message == "Unauthorized")
        //    //    {
        //    //        SwitchToLogin();
        //    //    }
        //    //}

        //}

        protected override void OnPause()
        {
            base.OnPause();
            Log.Debug(TAG, "On Pause");
            //barcodeDecoder.Close();

            //if (uhfAPI.IsWorking)
            //{
            //    uhfAPI.StopInventory();
            //}
            //uhfAPI.Free();
            //Log.Debug(TAG, "Free RFID and Close Barcode");
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        #region Fragment
        public BaseFragment GetFragment(FragmentType fragmentType)
        {
            var fragmentsarry = SupportFragmentManager.Fragments;
            Type type;
            switch (fragmentType)
            {
                case FragmentType.Home:
                    type = typeof(HomeFragment);
                    break;
                case FragmentType.None:
                default:
                    return null;
            }

            foreach (var fragment in fragmentsarry)
            {
                if (fragment.GetType().Equals(type))
                {
                    return (BaseFragment)fragment;
                }
            }

            return null;
        }
        public void SwitchFragment(FragmentType fragmentType, Bundle bundle = null)
        {
            BaseFragment fragment = null;
            string fragmentTag = "";
            switch (fragmentType)
            {
                case FragmentType.Home:
                    fragment = new HomeFragment(this);
                    fragmentTag = HomeFragment.TAG;
                    break;
                case FragmentType.Login:
                    fragment = new LoginFragment(this);
                    fragmentTag = LoginFragment.TAG;
                    break;
                default:
                    break;
            }
            fragment.Arguments = bundle;
            AndroidX.Fragment.App.Fragment tag = SupportFragmentManager.FindFragmentByTag(fragmentTag);
            if (tag == null)
            {
                SupportFragmentManager.BeginTransaction()
                    .Add(Resource.Id.fragmentContainer, fragment, fragmentTag)
                    .AddToBackStack(fragmentTag).Commit();
            }
        }

        public void SwitchToLogin()
        {
            int backstackEntryCount = SupportFragmentManager.BackStackEntryCount;
            for (int i = 0; i < backstackEntryCount; i++)
            {
                var entry = SupportFragmentManager.GetBackStackEntryAt(i);
                if (entry.Name == LoginFragment.TAG)
                {
                    SupportFragmentManager.PopBackStack(entry.Id, 0);
                }

            }

        }

        #endregion
        #region Dialog
        public void ShowToast(string msg, bool lengthLong)
        {
            Message handlerMsg = new Message();

            handlerMsg.What = ((int)FragmentType.None);

            Bundle bundle = new Bundle();

            bundle.PutInt(ExtraName.HandleMsg, (int)HandlerMsg.Toast);
            bundle.PutString(ExtraName.Text, msg);
            bundle.PutInt(ExtraName.Number, lengthLong ? 1 : 0);

            handlerMsg.Data = bundle;

            handler.SendMessage(handlerMsg);
        }

        public void ShowMessage(string title, string msg)
        {
            Message handlerMsg = new Message();

            Bundle data = new Bundle();

            data.PutString(ExtraName.Title, title);
            data.PutString(ExtraName.Text, msg);
            data.PutInt(ExtraName.HandleMsg, (int)HandlerMsg.Message);

            handlerMsg.What = (int)FragmentType.None;
            handlerMsg.Data = data;
            handler.SendMessage(handlerMsg);
        }



        public void ShowLoading()
        {
            Message handlerMsg = new Message();
            Bundle data = new Bundle();


            data.PutInt(ExtraName.HandleMsg, (int)HandlerMsg.ShowLoading);

            handlerMsg.What = (int)FragmentType.None;
            handlerMsg.Data = data;
            handler.SendMessage(handlerMsg);
        }

        public void HideLoading()
        {
            Message handlerMsg = new Message();
            Bundle data = new Bundle();


            data.PutInt(ExtraName.HandleMsg, (int)HandlerMsg.HideLoading);

            handlerMsg.What = (int)FragmentType.None;
            handlerMsg.Data = data;
            handler.SendMessage(handlerMsg);
        }
        #endregion
    }
}