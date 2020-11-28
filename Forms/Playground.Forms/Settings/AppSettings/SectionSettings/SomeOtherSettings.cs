using System.ComponentModel.DataAnnotations;

namespace Playground.Forms.Settings.AppSettings.SectionSettings
{
    public class SomeOtherSettings
    {
        [RegularExpression(@"^[a-zA-Z0-9''-'\s]{1,40}$")]
        public string Key1 { get; private set; }
        [Range(0, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Key2 { get; private set; }
        public bool Key3 { get; private set; }
    }
}
