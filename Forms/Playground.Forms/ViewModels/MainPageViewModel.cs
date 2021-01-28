using Apizr;
using Playground.Forms.Services.Apis;
using Prism.Navigation;

namespace Playground.Forms.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService, IApizrManager<IMovieApi> movieManager)
            : base(navigationService)
        {
            Title = "Hello from Xamarin.Forms, Shiny, Prism & ReactiveUI!";

            //Log.Write("TestEvent", "TestDescription");
            //try
            //{
            //    Crashes.GenerateTestCrash();
            //}
            //catch (System.Exception ex)
            //{
            //    Log.Write(ex, ("testKey", "testValue"));
            //}
        }
    }
}
