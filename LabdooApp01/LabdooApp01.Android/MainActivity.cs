using Android.App;
using Android.Content.PM;
using Android.OS;
using System.Net;

namespace LabdooApp01.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

/*
#if DEBUG
            ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
#endif*/


            base.OnCreate(bundle);
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}