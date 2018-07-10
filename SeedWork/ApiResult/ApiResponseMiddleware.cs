using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YYY.Microservices.Domain.SeedWork
{
    public class ApiResponseMiddleware : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult @object)
            {
                context.Result = new ObjectResult(new ApiResponse(@object?.Value));
            }
            else if (context.Result is EmptyResult empty)
            {
                context.Result = new ObjectResult(new ApiResponse());
            }
            else if (context.Result is JsonResult json)
            {
                context.Result = new ObjectResult(new ApiResponse(json?.Value));
            }
            else if (context.Result is ContentResult content)
            {
                context.Result = new ObjectResult(new ApiResponse(content?.Content));
            }
            else if (context.Result is StatusCodeResult status)
            {
                context.Result = new ObjectResult(new ApiResponse());
            }
        }
    }
}
