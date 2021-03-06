using System;
using Playground.Forms.Navigation;
using Prism.Magician;
using Prism.Navigation;
using Xamarin.Forms;

namespace Playground.Forms
{
    [AutoRegisterViews]
    public partial class App
    {
        public App()
        {
        }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync($"{NavigationKeys.NavigationPage}/{NavigationKeys.MainPage}")
                .OnNavigationError(OnNavigationError);
        }

        private void OnNavigationError(Exception ex)
        {
            System.Diagnostics.Debugger.Break();
        }
    }
}
