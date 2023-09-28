using Microsoft.Extensions.Primitives;
using Neshan.Application.IServices;

namespace Neshan.Site.Handlers
{
    public class ShortUrlRedirectMidelwear
    {
        private readonly RequestDelegate _next;
        private IShortUrlService _linkService;

        public ShortUrlRedirectMidelwear(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //_linkService = httpContext.RequestServices.GetService(typeof(IShortUrlService));
            //var userAgent = StringValues.Empty;
            //httpContext.Request.Headers.TryGetValue("User-Agent", out userAgent);

            //if (httpContext.Request.Path.ToString().Length == 9)
            //{
            //    await _linkService.AddUserAgent(userAgent);
            //    var token = httpContext.Request.Path.ToString().Substring(1);
            //    var shortUrl = await _linkService.FindUrlByToken(token);
            //    await _linkService.AddRequestUrl(token);
            //    if (shortUrl != null)
            //    {
            //        httpContext.Response.Redirect(shortUrl.OrginalUrl.ToString());
            //    }
            //    else
            //    {
            //        httpContext.Response.Redirect(httpContext.Request.Host.ToString());
            //    }
            //}
            //await _next(httpContext);
        }

        public static class ShortUrlRedirectMidelwearExtensions
        {
            //public static IApplicationBuilder UseShortUrlRedirect(this IApplicationBuilder builder)
            //{
            //    return builder.UseMiddleware<ShortUrlRedirectMidelwear>();
            //}
        }
    }
}
