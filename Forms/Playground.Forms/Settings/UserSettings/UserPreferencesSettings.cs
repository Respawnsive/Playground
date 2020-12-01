using System.ComponentModel;
using System.Globalization;
using Prism.Magician;
using Shiny.Settings;

namespace Playground.Forms.Settings.UserSettings
{
    public partial class UserPreferencesSettings : UserSettingsBase
    {
        public UserPreferencesSettings(ISettings settings) : base(settings)
        {
        }

        [Reactive, DefaultValue(null)]
        public CultureInfo SelectedCulture { get; set; }
    }
}
