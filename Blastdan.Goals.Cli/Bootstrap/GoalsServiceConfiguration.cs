using Blastdan.BambooHr.Infrastructure.Respositories;
using Blastdan.Goals.Domain.Models;
using Blastdan.Goals.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console;

namespace Blastdan.Goals.Cli.Bootstrap
{
    public static class GoalsServiceConfiguration
    {
        public static void Configure(HostBuilderContext context, IServiceCollection services)
        {
            /*
            Add framework dependencies to the container
            */
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(BambooHrConfigurations).Assembly, typeof(Employee).Assembly);
            });
            services.AddSingleton<IAnsiConsole>((provider) => AnsiConsole.Console);

            /*
            Configure BambooHr
            */
            BambooHrConfigurations.Configure(context, services);

            /*
            Configure the dependency injection
            */

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IFileCacheRepository, FileCacheRepository>();
        }
    }
}
