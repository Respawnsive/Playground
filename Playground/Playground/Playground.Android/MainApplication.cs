using System;
using Android.App;
using Android.Runtime;
using Shiny;

namespace Playground.Droid
{
    [Application(Theme = "@style/MainTheme")]
    public class MainApplication : ShinyAndroidApplication<MainStartup>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
    }
}
