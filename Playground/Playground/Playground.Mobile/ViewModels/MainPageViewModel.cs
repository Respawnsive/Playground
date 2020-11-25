using Playground.Mobile.Services;

namespace Playground.Mobile.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(BaseServices baseServices)
            : base(baseServices)
        {
            Title = "Hello from Xamarin.Forms, Shiny, Prism & ReactiveUI!";
        }
    }
}
