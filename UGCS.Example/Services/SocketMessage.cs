namespace Services
{
    internal class SocketMessage
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    internal enum MessageType
    {
        WindowsClient,
        WebClient,
        NewPacket,
        Command,
        ReadWaypoints,
        WriteWayPoints
    }

    internal class IncomingMessage
    {
        public MessageType Type { get; set; }
        public string Value { get; set; }
        public float alt { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
    }

    internal class UTMResponse
    {
        public int? HttpStatusCode { get; set; }
        public string Message { get; set; }
        public string Resource { get; set; }
    }
}