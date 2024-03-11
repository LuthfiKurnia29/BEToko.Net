using Microsoft.Extensions.DependencyInjection;

namespace application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
      {
         var assembly = typeof(DependencyInjection).Assembly;
         services.AddAutoMapper(assembly);
         services.AddMediatR(conf => conf.RegisterServicesFromAssembly(assembly));
         
      }
}