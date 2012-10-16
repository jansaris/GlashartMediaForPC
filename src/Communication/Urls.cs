namespace Communication
{
    public static class Urls
    {
        public const string Server = "http://qk.zt6.nl/";
        //{0} == Code from box
        //{1} == Name for this application
        public const string StartCreateConnection = "ipadserver/connection/requestConnection?code={0}&description={1}&token={2}&seq={3}";
        public const string CreateConnectionPoll = "ipadserver/connection/status?connectionIdentifier={0}&token={1}&seq={2}";
    }
}
