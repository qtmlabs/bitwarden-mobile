using Android.Content;
using Android.OS;
using Bit.Core.Utilities.Fido2;
using Java.Lang;
using Exception = System.Exception;

namespace Bit.App.Droid.Utilities
{
    public static class IntentExtensions
    {
        public static void Validate(this Intent intent)
        {
            try
            {
                // Check if getting the bundle of the extras causes any exception when unparcelling
                // Note: getting the bundle like this will cause to call unparcel() internally
                var b = intent?.Extras?.GetBundle("trashstringwhichhasnousebuttocheckunparcel");
            }
            catch (Exception ex) when
            (
                ex is BadParcelableException ||
                ex is ClassNotFoundException ||
                ex is RuntimeException
            )
            {
                intent.ReplaceExtras((Bundle)null);
            }
        }

        public static bool IsPasskeyHandlerIntent(this Intent intent)
        {
            return intent?.Component?.ClassName == "com.x8bit.bitwarden.PasskeyHandlerActivity";
        }

        public static string GetFido2CredentialAction(this Intent intent)
        {
            if (!intent.IsPasskeyHandlerIntent()) return null;
            return intent.GetStringExtra(CredentialProviderConstants.Fido2CredentialAction);
        }
    }
}
