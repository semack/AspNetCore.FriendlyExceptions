using System;
using AspNetCore.FriendlyExceptions.Options;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.FriendlyExceptions.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFriendlyExceptionsTransforms(this IServiceCollection services,
            Action<TranformOptions> setupAction)
        {
            services.Configure(setupAction);
        }
    }
}