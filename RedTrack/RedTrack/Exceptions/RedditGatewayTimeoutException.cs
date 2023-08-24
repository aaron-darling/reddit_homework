using System;
using System.Runtime.Serialization;

namespace Reddit.Exceptions
{
    [Serializable]
    public class RedditGatewayTimeoutException : Exception
    {


        public RedditGatewayTimeoutException(string message)
            : base(message) { }

    }
}
