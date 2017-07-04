using System;
using System.Threading.Tasks;
using AspNetCore.FriendlyExceptions.Extensions;
using AspNetCore.FriendlyExceptions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace AspNetCore.FriendlyExceptions
{
    internal class FriendlyExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<TranformOptions> _options;

        public FriendlyExceptionsMiddleware(RequestDelegate next,
            IOptions<TranformOptions> options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await context.HandleExceptionAsync(_options, exception);
            }
        }
    }
}