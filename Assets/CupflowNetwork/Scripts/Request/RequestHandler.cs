using Newtonsoft.Json;
using UnityEngine.Events;

namespace CupflowNetwork
{
    public abstract class RequestHandler<T, S>
    {
        public UnityAction<T> OnResponse { get; private set; }
        public UnityAction<string> OnError { get; private set; }
        public string Action { get; private set; }
        public S Params { get; private set; }

        private string requestId;
        public RequestHandler(string action, S _params, UnityAction<T> onResponse, UnityAction<string> onError)
        {
            OnResponse = onResponse;
            Params = _params;
            Action = action;
            OnError = onError;
        }

        public void SendRequest()
        {
            Request<S> request = new Request<S>(Action, Params);

            WebsocketManager.Instance.Send(JsonConvert.SerializeObject(request));

            requestId = request.Header.Id;

            WebsocketManager.Instance.OnWebsocketResponse += CheckResponse;
        }

        private void CheckResponse(Response res)
        {
            ThreadDispatcher.RunOnMainThread(() =>
            {
                if (res.Header.Id != requestId) return;

                if (res.Body.Status == MessageStatus.ERROR)
                {
                    OnError.Invoke(res.Body.Error);
                }

                if (res.Body.Status == MessageStatus.SUCCESS)
                {
                    try
                    {
                        T data = JsonConvert.DeserializeObject<T>(res.Body.Data);
                        OnResponse.Invoke(data);
                    }
                    catch(System.Exception e)
                    {
                        OnError.Invoke("Invalid Data: " + e.Message);
                    }
                }

                WebsocketManager.Instance.OnWebsocketResponse -= CheckResponse;
            });

        }
    }


}