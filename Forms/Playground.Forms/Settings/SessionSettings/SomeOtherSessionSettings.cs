using ReactiveUI.Fody.Helpers;

namespace Playground.Forms.Settings.SessionSettings
{
    public partial class SomeOtherSessionSettings : SessionSettingsBase
    {
        [Reactive]
        public int Key2 { get; set; }
    }
}
