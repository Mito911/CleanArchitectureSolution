using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Presentation.RazorPages.Middleware
{
    public class HttpHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Przykład dodania niestandardowego nagłówka
            context.Response.Headers.Add("X-Custom-Header", "HeaderValue");

            // Przekazanie żądania dalej w potoku middleware
            await _next(context);
        }
    }
}

