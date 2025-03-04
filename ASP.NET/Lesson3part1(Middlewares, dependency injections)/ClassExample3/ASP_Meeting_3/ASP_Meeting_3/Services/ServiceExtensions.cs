using ASP_Meeting_3.Services.Abstract;
using ASP_Meeting_3.Services.Implementation;

namespace ASP_Meeting_3.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMyMessageService(
            this IServiceCollection services)
        {
            services.AddTransient<IMessageService, BasicHtmlMessageService>();
            return services;
        }
    }
}
