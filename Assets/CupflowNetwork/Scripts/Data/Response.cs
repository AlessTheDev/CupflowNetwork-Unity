namespace CupflowNetwork
{
    [System.Serializable]
    public class Response
    {
        public ResponseHeader Header { get; set; }
        public ResponseBody Body { get; set; }
    }

    [System.Serializable]
    public class ResponseHeader
    {
        public MessageType Type { get; set; }
        public string Id { get; set; }
    }

    [System.Serializable]
    public class ResponseBody
    {
        public string Status { get; set; }
        public string Data { get; set; }
        public string Error { get; set; }
    }

    public enum MessageType
    {
        REQUEST,
        RESPONSE
    }

}
