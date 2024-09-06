using Android.OS;
using Android.Widget;
using NhatMinhQCI.Components;
using NhatMinhQCI.Enums;
using System;
using System.Runtime.CompilerServices;

namespace TrainningXamarin.Fragments
{
    public abstract class BaseFragment : AndroidX.Fragment.App.Fragment
    {
        protected MainActivity _activity;
        protected void InitFragment(MainActivity activity)
        {
            this._activity = activity;
        }
        public abstract void ReceiveHandler(Bundle data);


    }
    public class BaseHandler : Java.Lang.Object, Handler.ICallback
    {
        private MainActivity _activity;
        private DisplayAlert displayAlert;


        public BaseHandler(MainActivity activity)
        {
            this._activity = activity;
            InitAlertDlg();
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool HandleMessage(Message msg)
        {
            FragmentType fragmentType = (FragmentType)msg.What;
            BaseFragment baseFragment = _activity.GetFragment(fragmentType);
            try
            {
                if (baseFragment != null)
                {
                    baseFragment.ReceiveHandler(msg.Data);
                }
                else if (fragmentType == FragmentType.None)
                {
                    HandlerProcess(msg.Data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        private void HandlerProcess(Bundle bundle)
        {
            HandlerMsg msgType = (HandlerMsg)bundle.GetInt(ExtraName.HandleMsg);

            switch (msgType)
            {
                case HandlerMsg.Toast:
                    ShowToast(bundle);
                    break;
                case HandlerMsg.Message:
                    ShowMessage(bundle);
                    break;
                case HandlerMsg.ShowLoading:
                    ShowLoading();
                    break;
                case HandlerMsg.HideLoading:
                    HideLoading();
                    break;

            }
        }

        private void ShowToast(Bundle bundle)
        {
            string data = bundle.GetString(ExtraName.Text);
            bool length = (bundle.GetInt(ExtraName.Number, 1) == 1);
            Toast.MakeText(_activity.ApplicationContext, data, length ? ToastLength.Long : ToastLength.Short).Show();
        }

        void ShowMessage(Bundle bundle)
        {
            string title = bundle.GetString(ExtraName.Title);
            string message = bundle.GetString(ExtraName.Text);
            displayAlert.ShowMessage(title, message);
        }



        void InitAlertDlg()
        {
            displayAlert = new DisplayAlert(_activity);
        }

        void ShowLoading()
        {
            _activity.loadingProgress.ShowDialog();
        }

        void HideLoading()
        {
            _activity.loadingProgress.Dismiss();
        }
    }
}