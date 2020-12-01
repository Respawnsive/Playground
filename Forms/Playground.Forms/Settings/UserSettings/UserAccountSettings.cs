using Prism.Magician;
using Shiny.Settings;

namespace Playground.Forms.Settings.UserSettings
{
    public partial class UserAccountSettings : UserSettingsBase
    {
        public UserAccountSettings(ISettings settings) : base(settings)
        {
        }

        [Reactive, Unclearable]
        public string UserId { get; set; }

        [Reactive]
        public string Username { get; set; }

        [Reactive]
        public string Email { get; set; }

        [Reactive, Secure]
        public string AuthToken { get; set; }
    }
}
