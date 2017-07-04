using System;
using System.Net;

namespace AspNetCore.FriendlyExceptions.Transforms.Interfaces
{
    public interface ITransformTo<T>
    {
        ITransformsMap To(HttpStatusCode statusCode, string reasonPhrase,
            Func<T, string> contentGenerator, string contentType = "text/plain");
    }
}