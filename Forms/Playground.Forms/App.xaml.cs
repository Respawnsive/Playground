using System;
using System.Diagnostics;
using Playground.Forms.ViewModels;
using Playground.Forms.Views;
using Prism.Events;
using Prism.Ioc;
using Prism.Navigation;
using Xamarin.Forms;

namespace Playground.Forms
{
    public partial class App
    {
        public App()
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync($"NavigationPage/MainPage");
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>(); 
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }

        protected override void OnNavigationError(INavigationError navigationError)
        {
#if DEBUG
            // Ensure we always break here while debugging!
            Debugger.Break();
#endif
            base.OnNavigationError(navigationError);
        }
    }
}
