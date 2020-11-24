using System;
using Playground.ViewModels;
using Playground.Views;
using Prism.Ioc;
using Prism.Magician;
using Prism.Navigation;
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
            NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}")
                .OnNavigationError(OnNavigationError);
        }

        private void OnNavigationError(Exception ex)
        {
            System.Diagnostics.Debugger.Break();
        }
    }
}
