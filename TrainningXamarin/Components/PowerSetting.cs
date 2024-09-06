using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using NhatMinhQCI.Utilities;
using System.Threading.Tasks;
using TrainningXamarin;

namespace NhatMinhQCI.Components
{
    public class PowerSetting
    {
        private readonly Context _context;
        private static AlertDialog dialog = null;
        public PowerSetting(Context context)
        {
            _context = context;

        }

        public async Task<int> ShowDialog(int currentPower)
        {
            LinearLayout.LayoutParams llParam = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            LinearLayout.LayoutParams llParamParent = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);

            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            LinearLayout llParent = new LinearLayout(_context);
            llParent.Orientation = Orientation.Vertical;
            llParent.LayoutParameters = llParamParent;

            LinearLayout ll = new LinearLayout(_context);
            ll.Orientation = Orientation.Horizontal;

            //llParam.Gravity = GravityFlags.Center;
            llParent.SetPadding(15, 15, 15, 15);
            llParam.SetMargins(15, 15, 15, 15);

            ll.LayoutParameters = llParamParent;


            TextView tvText = new TextView(_context);
            tvText.Text = StringUtil.GetResourceString(_context, Resource.String.power);
            tvText.TextSize = 20f;
            tvText.LayoutParameters = llParam;

            //ll.AddView(tvText);

            LinearLayout.LayoutParams sbParam = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.MatchParent);
            sbParam.Weight = 1;
            SeekBar sbPower = new SeekBar(_context);
            sbPower.Min = 1;
            sbPower.Max = 30;
            sbPower.Progress = currentPower;
            sbPower.LayoutParameters = sbParam;


            ll.AddView(sbPower);
            LinearLayout.LayoutParams tvPowerParam = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.MatchParent);
            tvPowerParam.Weight = 0.2f;
            TextView tvPower = new TextView(_context);
            tvPower.Text = currentPower.ToString();
            tvPower.TextSize = 20f;
            tvPower.LayoutParameters = tvPowerParam;
            ll.AddView(tvPower);
            sbPower.ProgressChanged += (s, e) =>
            {
                tvPower.Text = e.Progress.ToString();
            };

            GridLayout grLayout = new GridLayout(_context);
            grLayout.ColumnCount = 2;

            LinearLayout.LayoutParams grParam = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            grParam.Gravity = GravityFlags.Right;

            grLayout.LayoutParameters = grParam;

            Button btnCancel = new Button(_context);
            btnCancel.Text = StringUtil.GetResourceString(_context, Resource.String.cancel);
            btnCancel.LayoutParameters = llParam;

            Button btnAccept = new Button(_context);
            btnAccept.Text = StringUtil.GetResourceString(_context, Resource.String.ok);
            btnAccept.LayoutParameters = llParam;

            grLayout.AddView(btnAccept);
            grLayout.AddView(btnCancel);

            btnCancel.Click += (sender, e) =>
            {
                dialog.Dismiss();
            };
            btnAccept.Click += (sender, e) =>
            {
                tcs.TrySetResult(sbPower.Progress);
                dialog.Dismiss();
            };
            llParent.AddView(tvText);
            llParent.AddView(ll);
            llParent.AddView(grLayout);



            AlertDialog.Builder builder = new AlertDialog.Builder(_context);
            builder.SetCancelable(false);
            builder.SetView(llParent);


            dialog = builder.Create();

            dialog.Show();
            int result = await tcs.Task;
            return result;
        }
    }
}