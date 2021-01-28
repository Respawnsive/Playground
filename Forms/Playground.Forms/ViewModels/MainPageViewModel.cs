using Apizr;
using Microsoft.AppCenter.Crashes;
using Playground.Forms.Services;
using Playground.Forms.Services.Apis;
using Shiny.Logging;

namespace Playground.Forms.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(BaseServices baseServices, IApizrManager<IMovieApi> movieManager)
            : base(baseServices)
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
