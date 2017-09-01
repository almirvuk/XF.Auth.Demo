using XF.Auth.Demo.Authentication;

namespace XF.Auth.Demo.UWP {

    sealed partial class App {
        protected override void OnActivated(Windows.ApplicationModel.Activation.IActivatedEventArgs args) {
            if (args.Kind == Windows.ApplicationModel.Activation.ActivationKind.Protocol) {
                var protocolArgs = args as Windows.ApplicationModel.Activation.ProtocolActivatedEventArgs;
                try {


                AuthenticationState.Authenticator.OnPageLoading(protocolArgs.Uri);
                } catch (System.IO.FileLoadException exc_fl) {
                    throw new Xamarin.Auth.AuthException("UWP custom scheme exception", exc_fl);

                }
            }

            Windows.UI.Xaml.Window.Current.Activate();
        }
    }
}
