using System.ComponentModel.DataAnnotations;

namespace Playground.Forms.Settings.AppSettings
{
    public class SomeAppSettings : AppSettingsBase
    {
        private string _key1;
        [RegularExpression(@"^[a-zA-Z0-9;=_''-'\s]{1,100}$")]
        public string Key1
        {
            get => GetPlatformValue(ref _key1);
            private set => _key1 = value;
        }

        [Range(0, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Key2 { get; private set; }

        public bool Key3 { get; private set; }
    }
}
