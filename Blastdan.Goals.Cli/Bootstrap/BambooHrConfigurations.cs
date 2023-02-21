using System.Net.Http.Headers;
using System.Net.Http;
using Blastdan.BambooHr.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blastdan.Goals.Cli.Bootstrap
{
    public static class BambooHrConfigurations
    {

        public static void Configure(HostBuilderContext context, IServiceCollection services)
        {
            var config = context.Configuration;
            var bambooHrConfig = new BambooHrConfiguration();
            config.GetSection(BambooHrConfiguration.Section).Bind(bambooHrConfig);

            /*
            Configure the application configuration using the IOptions pattern
            */
            services.Configure<BambooHrConfiguration>(config.GetSection(BambooHrConfiguration.Section));

            /*
            Configure the HTTP Client used for communicating with BambooHr
            */
            services.AddHttpClient(BambooHrConfiguration.Section, httpClient =>
            {
                httpClient.BaseAddress = new Uri($"https://api.bamboohr.com/api/gateway.php/{bambooHrConfig.SubDomain}/v1/");

                // At the HTTP level, the API key is sent over HTTP Basic Authentication. Use the secret key as the username and any random string for the password.
                // https://documentation.bamboohr.com/docs
                httpClient.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue(bambooHrConfig.ApiKey, "X");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
        }
    }
}
