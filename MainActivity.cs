using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FlashLight
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        bool status = true;
        Button button;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            button = (Button)FindViewById(Resource.Id.onOff);
            button.Click +=Button_ClickAsync;

        }
        protected override void OnStart()
        {
            base.OnStart();

            try
            {
                // Turn Off Flashlight  
                 Flashlight.TurnOnAsync();
            }
            catch { }
        }

        private async void Button_ClickAsync(object sender, System.EventArgs e)
        {
            if (status == true)
            {
                status = false;
                button.Text = "ON";
                try
                {
                    // Turn Off Flashlight  
                    await Flashlight.TurnOffAsync();
                }
                catch { }



            }
            if (status == false)
            {
                status = true;
                button.Text = "OFF";
                try
                {
                    // Turn Off Flashlight  
                    await Flashlight.TurnOnAsync();
                }
                catch { }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}