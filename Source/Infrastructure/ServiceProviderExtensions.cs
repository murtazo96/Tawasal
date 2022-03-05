using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Tavenem.Blazor.IndexedDB;
using Tawasal;
using Tawasal.Data;

namespace Infrastructure
{
    /// <summary>
    /// Класс для регистрации кастомных сервисов как DI
    /// </summary>
    public static class ServiceProviderExtensions
    {
        public static void AddInfrastructureDIServices(this IServiceCollection services)
        {
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();
            services.AddIndexedDb(
                new IndexedDb<string>("Tawasal.Blazor.IndexedDB", 1));
        }
    }
}
