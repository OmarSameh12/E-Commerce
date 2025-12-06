using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Services.CacheService;
using System.Text;

namespace E_Commerce.Helper
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
 
    private readonly int _timeToLive;
        public CacheAttribute(int timeToLive)
        {
            _timeToLive = timeToLive;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
            var CacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);

            var CachedResponse=await cacheService.GetCacheResponseAsync(CacheKey);

            if (string.IsNullOrEmpty(CachedResponse)) {
                var contentResult = new ContentResult
                {
                    Content = CachedResponse,
                    ContentType="application/json",
                    StatusCode=200
                };
                context.Result = contentResult;
                return;
            }
            var excutedContext = await next();
            if (excutedContext.Result is OkObjectResult  response) {
                await cacheService.SetCacheResponseAsync(CacheKey,response.Value,TimeSpan.FromSeconds(_timeToLive));
            }

        }
        private string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var cacheKey = new StringBuilder();

            cacheKey.Append($"{request.Path}");

            foreach (var item in request.Query.OrderBy(x=>x.Key)) {
                cacheKey.Append($"{item.Key}-{item.Value}");
            }
            return cacheKey.ToString();

        }
    }
}
