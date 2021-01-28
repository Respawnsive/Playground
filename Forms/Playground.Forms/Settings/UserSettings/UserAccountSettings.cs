using System.ComponentModel;
using ReactiveUI.Fody.Helpers;
using Shiny.Settings;

namespace Playground.Forms.Settings.UserSettings
{
    public partial class UserAccountSettings : UserSettingsBase
    {
        [Reactive, Unclearable]
        public string UserId { get; set; }

        [Reactive, DefaultValue("Test")]
        public string Username { get; set; }

        [Reactive]
        public string Email { get; set; }

        [Reactive, Secure]
        public string AuthToken { get; set; }
    }
}
