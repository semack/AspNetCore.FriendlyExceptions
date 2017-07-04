using System;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.FriendlyExceptions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;

namespace AspNetCore.FriendlyExceptions.Extensions
{
    internal static class HttpContextExtensions
    {
        internal static async Task HandleExceptionAsync(this HttpContext context,
            IOptions<TranformOptions> options,
            Exception exception)
        {
            var transformer = options.Value.Transforms?.FindTransform(exception);
            if (transformer == null)
                throw exception;

            var content = transformer.GetContent(exception);

            context.Response.ContentType = transformer.ContentType;
            context.Response.StatusCode = (int) transformer.StatusCode;
            context.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = transformer.ReasonPhrase;
            context.Response.ContentLength = Encoding.UTF8.GetByteCount(content);
            await context.Response.WriteAsync(content);
        }
    }
}