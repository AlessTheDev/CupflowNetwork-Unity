using System;

namespace CupflowNetwork
{
    public class Request<T>
    {
        public RequestHeader Header { get; set; }
        public RequestBody<T> Body { get; set; }

        public Request(string action, T _params) 
        {
            Header = new RequestHeader(Guid.NewGuid().ToString());
            Body = new RequestBody<T>(action, _params);
        }
    }

    [Serializable]
    public class RequestHeader
    {
        public string Type = "REQUEST";
        public string Id { get; set; }

        public RequestHeader(string id)
        {
            Id = id;
        }
    }

    [Serializable]
    public class RequestBody<T>
    {
        public string Action { get; set; }
        public T Params { get; set; }

        public RequestBody(string action, T _params)
        {
            Action = action;
            Params = _params;
        }
    }
}
