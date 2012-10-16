namespace Communication.Responses
{
    public class Response
    {
        public string status { get; set; }

        public const string StatusOk = "ok";
        public const string StatusPending = "pending";
    }
}
