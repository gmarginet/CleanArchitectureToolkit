using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.TodoService.Infrastructure.Database;

public static class ServiceCollectionExtensions
{
    public static void AddCatDemoDatabase(this IServiceCollection services)
    {
        services.AddSingleton<IDemoDatabase, DemoDatabase>();
    }
}