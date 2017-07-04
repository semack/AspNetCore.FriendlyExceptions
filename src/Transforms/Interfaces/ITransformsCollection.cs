using System;

namespace AspNetCore.FriendlyExceptions.Transforms.Interfaces
{
    public interface ITransformsCollection
    {
        ITransform FindTransform(Exception exception);
    }
}