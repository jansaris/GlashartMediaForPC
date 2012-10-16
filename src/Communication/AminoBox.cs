using System;
using Communication.Exceptions;
using Communication.Responses;

namespace Communication
{
    public class AminoBox
    {
        private int _sequence;
        private int Sequence { get { return ++_sequence; } }
        private string ConnectionPollUrl { get { return string.Format(Urls.CreateConnectionPoll, _connectionIdentifier, _token, Sequence); } }

        private readonly Guid _token = Guid.NewGuid();
        private string _connectionIdentifier = string.Empty;

        public event EventHandler<TypedEventArgs<string>> Update;

        public ConnectionCreatedResponse RegisterOnBox(string code, string description)
        {
            var url = string.Format(Urls.StartCreateConnection, code, description.Replace(' ', '+'), _token, Sequence);
            var response = JsonCommunicator.GetSync<CreateConnectionResponse>(Urls.Server, url);
            if (response.status != Response.StatusOk)
            {
                throw new UnExpectedResponseStatus(response.status);
            }
            _connectionIdentifier = response.connectionIdentifier;
            var poll = JsonCommunicator.GetSync<ConnectionCreatedResponse>(Urls.Server, ConnectionPollUrl);
            while (poll.status == Response.StatusPending)
            {
                poll = JsonCommunicator.GetSync<ConnectionCreatedResponse>(Urls.Server, ConnectionPollUrl);
            }
            return poll;
        }

        private void OnUpdate(string message)
        {
            var handler = Update;
            if (handler != null)
            {
                handler.Invoke(this, new TypedEventArgs<string>(message));
            }
        }
    }
}
