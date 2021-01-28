using Prism.Navigation;

namespace Playground.Forms.ViewModels
{
    public partial class AnotherPageViewModel : ViewModelBase
    {
        public AnotherPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
