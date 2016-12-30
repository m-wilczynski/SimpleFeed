namespace SimpleFeed._IoC
{
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;

    public static class IocExtensions
    {
        public static T GetSingletonInstance<T>(this IServiceCollection services) where T : class
        {
            return services.FirstOrDefault(s => s.ServiceType == typeof(T)).ImplementationInstance as T;
        }
    }
}
