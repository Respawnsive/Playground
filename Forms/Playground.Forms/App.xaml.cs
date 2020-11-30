using System;
using Microsoft.Extensions.Options;
using Playground.Forms.Settings.SessionSettings;
using Prism.Magician;
using Prism.Navigation;
using Shiny;
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
            NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}")
                .OnNavigationError(OnNavigationError);

            var test = ShinyHost.Resolve<IOptions<SomeSessionSettings>>();
            test.Value.Key1 = true;
        }

        private void OnNavigationError(Exception ex)
        {
            System.Diagnostics.Debugger.Break();
        }
    }
}
