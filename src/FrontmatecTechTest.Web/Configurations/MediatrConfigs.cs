using Ardalis.SharedKernel;
using FrontmatecTechTest.Core.ContributorAggregate;
using FrontmatecTechTest.UseCases.Contributors.Create;
using MediatR;
using System.Reflection;
using FrontmatecTechTest.Core;

namespace FrontmatecTechTest.Web.Configurations;

public static class MediatrConfigs
{
  public static IServiceCollection AddMediatrConfigs(this IServiceCollection services)
  {
    var mediatRAssemblies = new[]
      {
        Assembly.GetAssembly(typeof(Contributor)), // Core
        Assembly.GetAssembly(typeof(ProcessCell)) // Core
        //Assembly.GetAssembly(typeof(CreateContributorCommand)) // UseCases
        //Assembly.GetAssembly(typeof(CreateProcessCellCommand))  // UseCases
      };

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
            .AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();

    return services;
  }
}
