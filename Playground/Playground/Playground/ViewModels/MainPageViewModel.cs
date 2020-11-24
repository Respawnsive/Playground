using Playground.Services;
using Prism.Magician;

namespace Playground.ViewModels
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
