using System;
using System.Runtime.Serialization;

namespace Reddit.Exceptions
{
    [Serializable]
    public class RedditBadRequestException : Exception
    {


        public RedditBadRequestException(string message)
            : base(message) { }

    }
}
