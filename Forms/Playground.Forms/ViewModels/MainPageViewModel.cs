using Microsoft.AppCenter.Crashes;
using Playground.Forms.Services;
using Shiny.Logging;

namespace Playground.Forms.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(BaseServices baseServices)
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
