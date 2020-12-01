using Prism.Magician;
using ReactiveUI;

namespace Playground.Forms.Settings.SessionSettings
{
    public partial class SomeOtherSessionSettings : ReactiveObject
    {
        [Reactive]
        public int Key2 { get; set; }
    }
}
