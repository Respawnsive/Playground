using Playground.ViewModels;
using Playground.Views;
using Prism.Ioc;
using Prism.Magician;
using Xamarin.Forms;

namespace Playground
{
    [AutoRegisterViews]
    public partial class App
    {
        public App()
        {
        }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
