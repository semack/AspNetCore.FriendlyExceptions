using Microsoft.AspNetCore.Builder;

namespace AspNetCore.FriendlyExceptions.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseFriendlyExceptions(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseMiddleware<FriendlyExceptionsMiddleware>();
        }
    }
}