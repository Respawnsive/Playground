using System.ComponentModel;
using System.Globalization;
using ReactiveUI.Fody.Helpers;

namespace Playground.Forms.Settings.UserSettings
{
    public partial class UserProfileSettings : UserSettingsBase
    {
        [Reactive, DefaultValue(null)]
        public CultureInfo SelectedCulture { get; set; }
    }
}
