using Microsoft.Extensions.Options;
using Playground.Forms.Services;
using Playground.Forms.Settings.App;
using Playground.Forms.Settings.Session;

namespace Playground.Forms.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(BaseServices baseServices, 
            IOptions<AppCenterSettings> appCenterSettings,
            IOptions<SomeSessionSettings> someSessionSettings)
            : base(baseServices)
        {
            Title = "Hello from Xamarin.Forms, Shiny, Prism & ReactiveUI!";
        }
    }
}
