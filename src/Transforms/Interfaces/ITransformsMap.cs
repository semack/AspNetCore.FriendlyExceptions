using System;

namespace AspNetCore.FriendlyExceptions.Transforms.Interfaces
{
    public interface ITransformsMap
    {
        ITransformTo<T> Map<T>() where T : Exception;
        ITransformTo<Exception> Map(Func<Exception, bool> matcher);
        ITransformTo<Exception> MapAllOthers();
        ITransformsCollection Done();
    }
}