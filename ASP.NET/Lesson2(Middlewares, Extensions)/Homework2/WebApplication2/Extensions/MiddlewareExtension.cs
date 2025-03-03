using WebApplication2.Middlewares;

namespace WebApplication2.Extensions
{

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyAuthorization(this IApplicationBuilder app, string userSecret)
        {
            return app.UseMiddleware<MyAuthorizationMiddleware>(userSecret);
        }
    }
}
