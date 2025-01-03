namespace WebApiDotNet.Middelwares
{
    public class TimeMiddleware
    {
        readonly RequestDelegate _next;

        public TimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Query.ContainsKey("name"))
            {
                await context.Response.WriteAsync($"Hello, {context.Request.Query["name"]}");
            }

            var time = DateTime.Now.ToString("HH:mm:ss");
            await context.Response.WriteAsync($"The time is: {time}");

        }   

    }

    public static class TimeMiddlewareExtensions
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
}
