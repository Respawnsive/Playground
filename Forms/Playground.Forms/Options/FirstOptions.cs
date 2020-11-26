using System.ComponentModel.DataAnnotations;

namespace Playground.Forms.Options
{
    public class FirstOptions
    {
        public const string Section = "Section1";

        [RegularExpression(@"^[a-zA-Z0-9''-'\s]{1,40}$")]
        public string Key1 { get; set; }
        [Range(0, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Key2 { get; set; }
        public bool Key3 { get; set; }
    }
}
