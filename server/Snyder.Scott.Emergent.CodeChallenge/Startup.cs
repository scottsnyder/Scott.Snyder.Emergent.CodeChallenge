using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Snyder.Scott.Emergent.CodeChallenge.Core.Interfaces;
using Snyder.Scott.Emergent.CodeChallenge.Services;

[assembly: FunctionsStartup(typeof(Snyder.Scott.Emergent.CodeChallenge.Startup))]

namespace Snyder.Scott.Emergent.CodeChallenge
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();
            builder.Services.AddScoped<IVersionService, VersionService>();
        }
    }
}
