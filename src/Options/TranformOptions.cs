using AspNetCore.FriendlyExceptions.Transforms.Interfaces;

namespace AspNetCore.FriendlyExceptions.Options
{
    public class TranformOptions
    {
        public virtual ITransformsCollection Transforms { get; set; }
    }
}