using System;
using System.Threading.Tasks;
using Apizr;
using Apizr.Logging;
using Apizr.Policing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Playground.Forms.Services.Apis;
using Playground.Forms.Settings.AppSettings;
using Playground.Forms.Settings.UserSettings;
using Polly;
using Polly.Extensions.Http;
using Polly.Registry;
using Shiny;

[assembly: LogIt]
[assembly: Policy("TransientHttpError")]
namespace Playground.Forms.Modules
{
    public class WebApiModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            var registry = new PolicyRegistry
            {
                {
                    "TransientHttpError", HttpPolicyExtensions.HandleTransientHttpError().WaitAndRetryAsync(new[]
                    {
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(10)
                    }, LoggedPolicies.OnLoggedRetry).WithPolicyKey("TransientHttpError")
                }
            };
            services.AddPolicyRegistry(registry);

            services.UseApizrFor<IMovieApi>(optionsBuilder =>
                optionsBuilder.WithBaseAddress(serviceProvider =>
                        serviceProvider.GetRequiredService<IOptions<TheMovieDbSettings>>().Value.MovieBaseUrl)
                    .WithAuthenticationHandler<IOptions<UserAccountSettings>, IOptions<TheMovieDbSettings>>( 
                        userAccountSettings => userAccountSettings.Value.AuthToken,
                        (theMovieDbSettings, message) => Task.FromResult(theMovieDbSettings.Value.ReadAccessToken)));
        }
    }
}
