using System.Threading.Tasks;
using AspNetCore.FriendlyExceptions.Extensions;
using AspNetCore.FriendlyExceptions.Options;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace AspNetCore.FriendlyExceptions
{
    public class FriendlyExceptionAttribute : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.Exception != null)
            {
                var options = context.HttpContext.RequestServices.GetService(typeof(IOptions<TranformOptions>)) as IOptions<TranformOptions>;
                await context.HttpContext.HandleExceptionAsync(options, context.Exception);
                context.ExceptionHandled = true;
            }
        }
    }
}