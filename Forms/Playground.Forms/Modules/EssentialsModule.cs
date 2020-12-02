using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

namespace Playground.Forms.Modules
{
    public class EssentialsModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            // Add Xamarin Essentials
            services.AddTransient<IAppInfo, AppInfoImplementation>();
            //services.AddTransient<IEmail, EmailImplementation>();
            //services.AddTransient<ISms, SmsImplementation>();
            // and so on...
        }
    }
}
