using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using XF.Auth.Demo.Authentication;

namespace XF.Auth.Demo.Droid {
    [Activity(Label = "XF.Auth.Demo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
        protected override void OnCreate(Bundle bundle) {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, bundle);

            global::Xamarin.Auth.CustomTabsConfiguration.ActionLabel = null;
            global::Xamarin.Auth.CustomTabsConfiguration.MenuItemTitle = null;
            global::Xamarin.Auth.CustomTabsConfiguration.AreAnimationsUsed = true;
            global::Xamarin.Auth.CustomTabsConfiguration.IsShowTitleUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsUrlBarHidingUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsCloseButtonIconUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsActionButtonUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsActionBarToolbarIconUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsDefaultShareMenuItemUsed = false;


            global::Android.Graphics.Color color_xamarin_blue;
            color_xamarin_blue = new global::Android.Graphics.Color(0x34, 0x98, 0xdb);
            global::Xamarin.Auth.CustomTabsConfiguration.ToolbarColor = color_xamarin_blue;
            LoadApplication(new App());
        }
    }
}

