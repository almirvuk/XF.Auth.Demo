using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Auth.Demo.Authentication; 

namespace XF.Auth.Demo.Views {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage {

        public Login() {
            InitializeComponent();


            
            FacebookButton.Clicked += FacebookLogin;

        }

        OAuth2Authenticator authenticator;

        private void FacebookLogin(object sender, EventArgs e) {

            string fb_app_id = "121718305150879";

            authenticator
                     = new Xamarin.Auth.OAuth2Authenticator
                     (
                         clientId:
                             new Func<string>
                                (
                                    () => {
                                        string retval_client_id = "oops something is wrong!";

                                        retval_client_id = fb_app_id;
                                        return retval_client_id;
                                    }
                                ).Invoke(),
                         //clientSecret: null,   // null or ""
                         authorizeUrl:
                             new Func<Uri>
                                (
                                    () => {
                                        string uri = null;
                                        uri = "https://www.facebook.com/v2.9/dialog/oauth";
                                        return new Uri(uri);
                                    }
                                ).Invoke(),
                         //accessTokenUrl: new Uri("https://www.googleapis.com/oauth2/v4/token"),
                         redirectUrl:
                             new Func<Uri>
                                (
                                    () => {
                                        string uri = null;
                                        uri = $"fb{fb_app_id}://authorize";
                                        return new Uri(uri);
                                    }
                                ).Invoke(),
                         scope: "email", // "basic", "email",
                         getUsernameAsync: null,
                         isUsingNativeUI: true
                     ) {
                         AllowCancel = true,
                     };

            authenticator.Completed +=
                (s, ea) => {
                    StringBuilder sb = new StringBuilder();

                    if (ea.Account != null && ea.Account.Properties != null) {
                        sb.Append("Token = ").AppendLine($"{ea.Account.Properties["access_token"]}");
                    } else {
                        sb.Append("Not authenticated ").AppendLine($"Account.Properties does not exist");
                    }

                    DisplayAlert
                            (
                                "Authentication Results",
                                sb.ToString(),
                                "OK"
                            );

                    return;
                };

            authenticator.Error +=
                (s, ea) => {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Error = ").AppendLine($"{ea.Message}");

                    DisplayAlert
                            (
                                "Authentication Error",
                                sb.ToString(),
                                "OK"
                            );
                    return;
                };

            // after initialization (creation and event subscribing) exposing local object 
            AuthenticationState.Authenticator = authenticator;

            PresentUILoginScreen(authenticator);

        }

        private void PresentUILoginScreen(OAuth2Authenticator authenticator) {

            // Presenters Implementation

            Xamarin.Auth.Presenters.OAuthLoginPresenter presenter = null;
            presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);

            return;
        }

    }
}