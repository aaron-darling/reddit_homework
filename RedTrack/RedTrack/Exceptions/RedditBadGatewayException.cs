using System;
using System.Runtime.Serialization;

namespace Reddit.Exceptions
{
    [Serializable]
    public class RedditBadGatewayException : Exception
    {

        public RedditBadGatewayException(string message)
            : base(message) { }

    }
}
