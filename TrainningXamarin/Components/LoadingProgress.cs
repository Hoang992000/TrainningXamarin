using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using NhatMinhQCI.Utilities;
using TrainningXamarin;

namespace NhatMinhQCI.Components
{
    public class LoadingProgress
    {
        private static AlertDialog dialog = null;
        private readonly Context _context;
        public LoadingProgress(Context context)
        {
            _context = context;
            Init();
        }

        private void Init()
        {
            int llPadding = 30;
            LinearLayout ll = new LinearLayout(_context);
            ll.Orientation = Orientation.Horizontal;
            ll.SetPadding(llPadding, llPadding, llPadding, llPadding);
            ll.SetGravity(GravityFlags.Center);

            LinearLayout.LayoutParams llParam = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            llParam.Gravity = GravityFlags.Center;
            ll.LayoutParameters = llParam;

            ProgressBar progressBar = new ProgressBar(_context);
            progressBar.Indeterminate = true;
            progressBar.SetPadding(0, 0, llPadding, 0);
            progressBar.LayoutParameters = llParam;


            TextView tvText = new TextView(_context);
            tvText.Text = StringUtil.GetResourceString(_context, Resource.String.message_loading);
            tvText.SetTextColor(Android.Graphics.Color.Black);
            tvText.TextSize = 20f;
            tvText.LayoutParameters = llParam;
            ll.AddView(progressBar);
            ll.AddView(tvText);

            AlertDialog.Builder builder = new AlertDialog.Builder(_context);
            builder.SetCancelable(false);
            builder.SetView(ll);

            // Displaying the dialog
            dialog = builder.Create();



            //Window window = dialog.Window;
            //if (window != null)
            //{
            //    WindowManagerLayoutParams layoutParams = new WindowManagerLayoutParams();
            //    layoutParams.CopyFrom(dialog.Window.Attributes);
            //    layoutParams.Width = LinearLayout.LayoutParams.WrapContent;
            //    layoutParams.Height = LinearLayout.LayoutParams.WrapContent;
            //    dialog.Window.Attributes = layoutParams;

            //    // Disabling screen touch to avoid exiting the Dialog
            //    window.SetFlags(WindowManagerFlags.NotTouchable, WindowManagerFlags.NotTouchable);

            //}
        }

        public void ShowDialog()
        {
            if (dialog != null)
            {
                dialog.Show();
            }
        }

        public void Dismiss()
        {
            if (dialog != null)
            {
                dialog.Dismiss();
            }

        }
    }
}