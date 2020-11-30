using System.ComponentModel;
using System.Globalization;
using Prism.Magician;
using Shiny.Settings;

namespace Playground.Forms.Settings.User
{
    public class UserAccountSettings : UserSettingsBase
    {
        public UserAccountSettings(ISettings settings) : base(settings)
        {
        }

        [Reactive]
        public string UserId { get; set; }

        [Reactive]
        public string Username { get; set; }

        [Reactive]
        public string Email { get; set; }

        [Reactive, Secure]
        public string AuthToken { get; set; }
    }
}
