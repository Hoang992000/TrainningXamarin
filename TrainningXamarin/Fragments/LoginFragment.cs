using Android.OS;
using Android.Views;
using Android.Widget;
using NhatMinhQCI.Components;
using System;

namespace TrainningXamarin.Fragments
{
    public class LoginFragment : BaseFragment
    {
        public static string TAG = "LoginFragment";
        private DisplayAlert displayAlert;
        private EditText edtUsername;
        private EditText edtPassword;
        private Button btnLogin;
        private ImageButton btnSetting;
        private CheckBox ckbRemember;
        private string BASE_URL = "";
        public LoginFragment(MainActivity activity)
        {
            InitFragment(activity);

        }

        private void Initialize()
        {
            displayAlert = new DisplayAlert(_activity);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.LoginLayout, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            FindViewById(view);
            SetButtonClick();
            Initialize();
            //InitializeData();
        }

        //private async void InitializeData()
        //{
        //    try
        //    {
        //        configRepository = await ConfigRepositories.Instance;
        //        string value = await configRepository.GetConfig("remember");
        //        string username = await configRepository.GetConfig("username");
        //        string password = await configRepository.GetConfig("password");
        //        BASE_URL = await configRepository.GetConfig("base_url");
        //        if (!string.IsNullOrEmpty(BASE_URL))
        //        {
        //            ApiHelper.InitializeClient(BASE_URL);
        //        }

        //        if (!string.IsNullOrEmpty(value))
        //        {
        //            ckbRemember.Checked = value == "0" ? false : true;
        //            if (ckbRemember.Checked)
        //            {
        //                edtUsername.Text = username;
        //                edtPassword.Text = password;
        //            }
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        displayAlert.ShowMessage("Notification", ex.ToString());
        //    }

        //}

        private void FindViewById(View view)
        {
            edtUsername = view.FindViewById<EditText>(Resource.Id.edtUsername);
            edtPassword = view.FindViewById<EditText>(Resource.Id.edtPassword);
            btnLogin = view.FindViewById<Button>(Resource.Id.btnLogin);
            ckbRemember = view.FindViewById<CheckBox>(Resource.Id.ckbRemember);
            //btnSetting = view.FindViewById<ImageButton>(Resource.Id.btnSetting);

        }

        private void SetButtonClick()
        {
            btnLogin.Click += BtnLogin_Click;
            //btnSetting.Click += BtnSetting_Click;
        }

        //private async void BtnSetting_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //string baseUrl = await configRepository.GetConfig("base_url");
        //        //string saveUrl = await displayAlert.ShowDialogForInput("BASE_URL", baseUrl);
        //        //if (Regex.IsMatch(saveUrl, @"^https?://(?:\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}|(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,})(?::\d{1,5})?(?:/.*|)$"))
        //        //{
        //        //    await configRepository.SaveConfig("base_url", saveUrl);
        //        //    ApiHelper.InitializeClient(saveUrl);
        //        //    BASE_URL = saveUrl;
        //        //}
        //        //else
        //        //{
        //        //    if (string.IsNullOrEmpty(saveUrl))
        //        //        return;
        //        //    _activity.ShowToast("Not Invalid!", true);
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        displayAlert.ShowMessage("Notification", ex.ToString());
        //    }
        //}

        private void BtnLogin_Click(object sender, EventArgs e)
        {


            try
            {
                _activity.ShowLoading();
                //string serial = Android.Provider.Settings.Global.GetString(MainActivity.contentResolver, "Serial");
                //string key = Encryptor.Base64EncodeAndMD5Hash(serial + "RFIDSTORE").ToUpper();
                //string loadKey = await settingRepository.GetSetting(serial);

                //if (key != loadKey)
                //{
                //    displayAlert.ShowMessage("Notification", string.Format("Your device is not register, please contact your RFID supplier!\r\n{0}", serial));
                //    return;
                //}

                //if (string.IsNullOrEmpty(BASE_URL))
                //{
                //    displayAlert.ShowMessage("Notification", "Please set base url first!");
                //    return;
                //}



                if (string.IsNullOrEmpty(edtUsername.Text) || string.IsNullOrEmpty(edtPassword.Text))
                {
                    displayAlert.ShowMessage("Notification", "Please enter your username and password!");
                    return;
                }
                //UserModel user = new UserModel();
                //user.UserName = edtUsername.Text;
                //user.UserPassword = edtPassword.Text;
                //string token = await userRepository.LoginAsync(user);

                //if (!string.IsNullOrEmpty(token))
                //{
                //    if (ckbRemember.Checked)
                //    {
                //        await configRepository.SaveConfig("remember", "1");
                //        await configRepository.SaveConfig("username", edtUsername.Text);
                //        await configRepository.SaveConfig("password", edtPassword.Text);
                //    }
                //    else
                //    {
                //        await configRepository.SaveConfig("remember", "0");
                //    }

                //    ApiHelper.SetTokenHeader(token);
                //    _activity.IsLoggedIn = true;
                //    _activity.CurrentUser = await userRepository.GetUserInfo();
                //    _activity.SwitchFragment(Enums.FragmentType.Home);
                //}
                if (edtUsername.Text == "admin" && edtPassword.Text == "admin")
                {
                    _activity.IsLoggedIn = true;
                    _activity.SwitchFragment(NhatMinhQCI.Enums.FragmentType.Home);
                }
            }
            catch (Exception ex)
            {
                displayAlert.ShowMessage("Notification", ex.Message);
            }
            finally
            {
                _activity.HideLoading();
            }

        }

        public override void ReceiveHandler(Bundle data)
        {
        }
    }
}