﻿using ReactiveUI.Fody.Helpers;

namespace Playground.Forms.Settings.SessionSettings
{
    public partial class SomeSessionSettings : SessionSettingsBase
    {
        [Reactive]
        public bool Key1 { get; set; }
    }
}
