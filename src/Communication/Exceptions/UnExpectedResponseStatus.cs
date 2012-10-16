using System;

namespace Communication.Exceptions
{
    public class UnExpectedResponseStatus : Exception
    {
        public string Status { get; private set; }

        public UnExpectedResponseStatus(string status)
        {
            Status = status;
        }
    }
}
