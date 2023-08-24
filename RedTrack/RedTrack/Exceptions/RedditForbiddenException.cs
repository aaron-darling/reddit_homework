using System;
using System.Runtime.Serialization;

namespace Reddit.Exceptions
{
    [Serializable]
    public class RedditForbiddenException : Exception
    {

        public RedditForbiddenException(string message)
            : base(message) { }

    }
}
