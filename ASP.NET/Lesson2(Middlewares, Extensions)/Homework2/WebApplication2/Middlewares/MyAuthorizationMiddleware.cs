namespace WebApplication2.Middlewares
{
    public class MyAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _userSecret;

        public MyAuthorizationMiddleware(RequestDelegate next, string userSecret)
        {
            _next = next;
            _userSecret = userSecret;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? token = context.Request.Query["token"];
            if (string.IsNullOrWhiteSpace(token) || token != _userSecret)
            {
                context.Response.StatusCode = 401;
                return;
            }
            await _next(context);
        }
    }
}
