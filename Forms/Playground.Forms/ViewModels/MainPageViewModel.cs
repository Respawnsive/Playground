using Microsoft.Extensions.Options;
using Playground.Forms.Services;
using Playground.Forms.Settings.AppSettings.Options;

namespace Playground.Forms.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(BaseServices baseServices, 
            IOptions<AppCenterOptions> appCenterOptions,
            IOptions<SomeOtherOptions> someOtherOptions)
            : base(baseServices)
        {
            Title = "Hello from Xamarin.Forms, Shiny, Prism & ReactiveUI!";
        }
    }
}
