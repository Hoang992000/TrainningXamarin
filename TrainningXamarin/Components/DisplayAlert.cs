using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using NhatMinhQCI.Utilities;
using System.Linq;
using System.Threading.Tasks;
using TrainningXamarin;

namespace NhatMinhQCI.Components
{
    public class DisplayAlert
    {
        private readonly Context _context;
        private static AlertDialog dialog = null;
        public DisplayAlert(Context context)
        {
            _context = context;

        }

        public void ShowMessage(string title, string message)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            LinearLayout ll = new LinearLayout(_context);
            ll.Orientation = Orientation.Vertical;

            LinearLayout.LayoutParams llParam = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);

            ll.SetPadding(15, 15, 15, 15);
            llParam.SetMargins(15, 15, 15, 15);

            ll.LayoutParameters = llParam;


            TextView tvTitle = new TextView(_context);
            tvTitle.Text = title;
            tvTitle.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
            tvTitle.TextSize = 18f;
            tvTitle.LayoutParameters = llParam;

            TextView tvMessage = new TextView(_context);
            tvMessage.Text = message;
            tvMessage.TextSize = 14f;
            tvMessage.LayoutParameters = llParam;


            ll.AddView(tvTitle);
            ll.AddView(tvMessage);

            GridLayout grLayout = new GridLayout(_context);
            grLayout.ColumnCount = 2;

            LinearLayout.LayoutParams grParam = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            grParam.Gravity = GravityFlags.Right;

            grLayout.LayoutParameters = grParam;

            Button btnAccept = new Button(_context);
            btnAccept.Text = "OK";
            btnAccept.LayoutParameters = llParam;

            grLayout.AddView(btnAccept);



            btnAccept.Click += (sender, e) =>
            {
                dialog.Dismiss();
            };

            ll.AddView(grLayout);



            AlertDialog.Builder builder = new AlertDialog.Builder(_context);
            builder.SetCancelable(false);
            builder.SetView(ll);


            dialog = builder.Create();

            dialog.Show();

        }

        public async Task<bool> ShowDialog(string title, string message)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            LinearLayout ll = new LinearLayout(_context);
            ll.Orientation = Orientation.Vertical;

            LinearLayout.LayoutParams llParam = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            //llParam.Gravity = GravityFlags.Center;
            ll.SetPadding(15, 15, 15, 15);
            llParam.SetMargins(15, 15, 15, 15);

            ll.LayoutParameters = llParam;


            TextView tvTitle = new TextView(_context);
            tvTitle.Text = title;
            tvTitle.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
            tvTitle.TextSize = 18f;
            tvTitle.LayoutParameters = llParam;

            TextView tvMessage = new TextView(_context);
            tvMessage.Text = message;
            tvMessage.TextSize = 14f;
            tvMessage.LayoutParameters = llParam;


            ll.AddView(tvTitle);
            ll.AddView(tvMessage);

            GridLayout grLayout = new GridLayout(_context);
            grLayout.ColumnCount = 2;

            LinearLayout.LayoutParams grParam = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            grParam.Gravity = GravityFlags.Right;

            grLayout.LayoutParameters = grParam;

            Button btnCancel = new Button(_context);
            btnCancel.Text = "Cancel";
            btnCancel.LayoutParameters = llParam;

            Button btnAccept = new Button(_context);
            btnAccept.Text = "OK";
            btnAccept.LayoutParameters = llParam;

            grLayout.AddView(btnAccept);
            grLayout.AddView(btnCancel);

            btnCancel.Click += (sender, e) =>
            {
                tcs.TrySetResult(false);
                dialog.Dismiss();
            };
            btnAccept.Click += (sender, e) =>
            {
                tcs.TrySetResult(true);
                dialog.Dismiss();
            };

            ll.AddView(grLayout);



            AlertDialog.Builder builder = new AlertDialog.Builder(_context);
            builder.SetCancelable(false);
            builder.SetView(ll);

            dialog = builder.Create();

            dialog.Show();
            bool result = await tcs.Task;
            return result;
        }

        public async Task<string> ShowDialogForInput(string message, string content = null)
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();

            LinearLayout ll = new LinearLayout(_context);
            ll.Orientation = Orientation.Vertical;

            LinearLayout.LayoutParams llParam = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
            //llParam.Gravity = GravityFlags.Center;
            ll.SetPadding(15, 15, 15, 15);
            llParam.SetMargins(15, 15, 15, 15);

            ll.LayoutParameters = llParam;


            TextView tvText = new TextView(_context);
            tvText.Text = message;
            tvText.TextSize = 20f;
            tvText.LayoutParameters = llParam;


            LinearLayout.LayoutParams edParam = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);

            EditText edText = new EditText(_context);
            edText.LayoutParameters = llParam;
            if (!string.IsNullOrEmpty(content))
            {
                edText.Text = content;
            }


            ll.AddView(tvText);
            ll.AddView(edText);


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
            btnAccept.Enabled = string.IsNullOrEmpty(content) ? false : true;
            btnAccept.LayoutParameters = llParam;

            edText.TextChanged += (s, e) =>
            {
                if (e.Text.Count() > 0)
                {
                    btnAccept.Enabled = true;
                }
                else
                {
                    btnAccept.Enabled = false;
                }
            };

            grLayout.AddView(btnAccept);
            grLayout.AddView(btnCancel);

            btnCancel.Click += (sender, e) =>
            {
                tcs.TrySetResult("");
                dialog.Dismiss();
            };
            btnAccept.Click += (sender, e) =>
            {
                tcs.TrySetResult(edText.Text);
                dialog.Dismiss();
            };

            ll.AddView(grLayout);



            AlertDialog.Builder builder = new AlertDialog.Builder(_context);
            builder.SetCancelable(false);
            builder.SetView(ll);

            dialog = builder.Create();

            dialog.Show();
            string result = await tcs.Task;
            return result;
        }
    }
}