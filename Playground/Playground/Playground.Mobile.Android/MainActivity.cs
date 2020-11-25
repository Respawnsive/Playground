using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Shiny;

namespace Playground.Mobile.Droid
{
    [Activity(Theme = "@style/MainTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Playground.Mobile.Droid.Resource.Layout.Tabbar;
            ToolbarResource = Playground.Mobile.Droid.Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            LoadApplication(new App());
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            this.ShinyOnNewIntent(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            this.ShinyRequestPermissionsResult(requestCode, permissions, grantResults);
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

