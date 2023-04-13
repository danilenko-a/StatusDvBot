using Microsoft.Extensions.DependencyInjection;

namespace StatusDvBot.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseStartUp<T>(this IServiceCollection services)
            where T : new()
        {
            var methods = typeof(T).GetMethods()
                .Select(x => new { Method = x, Parameters = x.GetParameters() })
                .Where(x => x.Parameters.Length == 1 && x.Parameters.All(p => p.ParameterType == typeof(IServiceCollection)))
                .Select(x => x.Method);

            var obj = new T();
            var @params = new object[] { services };

            foreach (var method in methods)
            {
                method.Invoke(obj, @params);
            }

            return services;
        }
    }
}
