using Microsoft.AspNetCore.Builder;

namespace Presentation.RESTAPI.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpHeadersMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpHeadersMiddleware>();
        }
    }
}
