using Microsoft.Extensions.Options;
using Playground.Forms.Services;
using Playground.Forms.Settings.AppSettings;

namespace Playground.Forms.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(BaseServices baseServices, 
            IOptions<AppCenterSettings> appCenterSettings,
            IOptions<SomeOtherSettings> someOtherSettings)
            : base(baseServices)
        {
            Title = "Hello from Xamarin.Forms, Shiny, Prism & ReactiveUI!";
        }
    }
}
