using System.ComponentModel;
using System.Globalization;
using Prism.Magician;
using Shiny.Settings;

namespace Playground.Forms.Settings.User
{
    public class UserPreferencesSettings : UserSettingsBase
    {
        public UserPreferencesSettings(ISettings settings) : base(settings)
        {
        }

        [Reactive, DefaultValue(null), Unclearable]
        public CultureInfo SelectedCulture { get; set; }
    }
}
