using Microsoft.Extensions.Options;
using Playground.Forms.Services;
using Playground.Forms.Settings.AppSettings;
using Playground.Forms.Settings.SessionSettings;

namespace Playground.Forms.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(BaseServices baseServices, 
            IOptions<AppCenterSettings> appCenterSettings,
            IOptions<SomeAppSettings> someOtherSettings, IOptions<SomeSessionSettings> someSessionSettings)
            : base(baseServices)
        {
            Title = "Hello from Xamarin.Forms, Shiny, Prism & ReactiveUI!";
        }
    }
}
