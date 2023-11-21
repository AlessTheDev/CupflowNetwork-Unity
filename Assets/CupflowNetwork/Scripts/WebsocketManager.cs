using UnityEngine;
using UnityEngine.Events;
using WebSocketSharp;
using Newtonsoft.Json;

namespace CupflowNetwork
{
    [System.Serializable]
    public class ResponseEvent : UnityEvent<Response> { }
    public class WebsocketManager : MonoBehaviour
    {
        public static WebsocketManager Instance { get; private set; }

        public event UnityAction OnWebsocketConnected;
        public event UnityAction<Response> OnWebsocketResponse;

        private bool isConnected = false;

        private void Awake()
        {
            if (Instance != null) return;

            Instance = this;

            Connect();
        }

        public void Connect()
        {
            if (isConnected) return;

            WebSocket webSocket = new WebSocket("ws://127.0.0.1:8080");

            webSocket.Connect();

            if (webSocket.IsAlive)
            {
                OnWebsocketConnected?.Invoke();
                isConnected = true;
            }

            webSocket.OnMessage += WebSocket_OnMessage;
        }


        private void WebSocket_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                Response parsedData = JsonConvert.DeserializeObject<Response>(e.Data);
                Debug.Log(parsedData.Header.Type);
                if (parsedData.Header.Type == MessageType.RESPONSE)
                {
                    OnWebsocketResponse?.Invoke(parsedData);
                }
            }
            catch (System.Exception ex)
            {
                Debug.Log($"[CUPFLOW NETWORK WEBSOCKET]\nError while parsing data:\n{ex}");
            }
        }
    }

}
