using Microsoft.Extensions.Options;
using Playground.Forms.Options;
using Playground.Forms.Services;

namespace Playground.Forms.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(BaseServices baseServices, IOptions<FirstOptions> firstOptions)
            : base(baseServices)
        {
            Title = "Hello from Xamarin.Forms, Shiny, Prism & ReactiveUI!";
        }
    }
}
