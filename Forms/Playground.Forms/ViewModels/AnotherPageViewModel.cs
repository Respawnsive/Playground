using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using Playground.Forms.Services;
using Playground.Forms.Settings.AppSettings;
using Playground.Forms.Settings.SessionSettings;
using Playground.Forms.Settings.UserSettings;
using Shiny.Settings;

namespace Playground.Forms.ViewModels
{
    public partial class AnotherPageViewModel : ViewModelBase
    {
        public AnotherPageViewModel(BaseServices baseServices) : base(baseServices)
        {
        }
    }
}
