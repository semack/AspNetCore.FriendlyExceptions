using System.Threading.Tasks;
using AspNetCore.FriendlyExceptions.Extensions;
using AspNetCore.FriendlyExceptions.Options;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace AspNetCore.FriendlyExceptions
{
    public class FriendlyExceptionAttribute : ExceptionFilterAttribute
    {
        private readonly IOptions<TranformOptions> _options;

        public FriendlyExceptionAttribute(IOptions<TranformOptions> options)
        {
            _options = options;
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.Exception != null)
            {
                await context.HttpContext.HandleExceptionAsync(_options, context.Exception);
                context.ExceptionHandled = true;
            }
        }
    }
}