using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing.Mobile;

namespace qr
{
    [Activity(Label = "qr", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

             MobileBarcodeScanner.Initialize(Application);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += Button_Click;

            button = FindViewById<Button>(Resource.Id.Exit);

            button.Click += ExitClick; ;

        }

        private void ExitClick(object sender, EventArgs e)
        {
            this.Finish();
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            var scanner = new MobileBarcodeScanner();
            var result = await scanner.Scan();

            FindViewById<TextView>(Resource.Id.textView1).Text = result.BarcodeFormat.ToString();
            FindViewById<TextView>(Resource.Id.textView2).Text = result.Text;

        }
    }
}

