using YYY.Microservices.Domain.SeedWork;

namespace Microsoft.AspNetCore.Mvc
{
    public static class ApiResponseMiddlewareExtensions
    {
        public static MvcOptions AddApiResponseFilter(this MvcOptions options)
        {
            options.Filters.Add(typeof(ApiResponseMiddleware));
            return options;
        }
    }
}
