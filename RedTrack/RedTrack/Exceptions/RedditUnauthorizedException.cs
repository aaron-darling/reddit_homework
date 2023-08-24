using System;
using System.Runtime.Serialization;

namespace Reddit.Exceptions
{
    [Serializable]
    public class RedditUnauthorizedException : Exception
    {

        public RedditUnauthorizedException(string message)
            : base(message) { }

    }
}
