using UnityEngine;
using UnityEngine.Events;
using WebSocketSharp;
using Newtonsoft.Json;

namespace CupflowNetwork
{
    /// <summary>
    /// This class handles all websocket operations for Cupflow Network Connection
    /// </summary>
    public class WebsocketManager : MonoBehaviour
    {
        public static WebsocketManager Instance { get; private set; }

        public event UnityAction OnWebsocketConnected;
        public event UnityAction<Response> OnWebsocketResponse;

        private WebSocket webSocket;

        private bool isConnected = false;

        private void Awake()
        {
            if (Instance != null) return;

            Instance = this;
        }

        /// <summary>
        /// Connect to the websocket though the port
        /// </summary>
        /// <param name="port">The port the server is initialized in</param>
        public void Connect(int port)
        {
            if (isConnected) return;

            webSocket = new WebSocket($"ws://127.0.0.1:{port}");

            webSocket.Connect();

            if (webSocket.IsAlive)
            {
                isConnected = true;
                OnWebsocketConnected?.Invoke();
            }

            webSocket.OnMessage += WebSocket_OnMessage;
        }

        /// <summary>
        /// Send a message though the connection
        /// </summary>
        /// <param name="message">The data that needs to be sent</param>
        /// <exception cref="CupflowNetworkNotConnectedException">If the websocket is not connected (use Connect)</exception>
        public void Send(string message)
        {
            if (!isConnected) throw new CupflowNetworkNotConnectedException("The websocket is not connected");
            webSocket.Send(message);
        }

        private void WebSocket_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                // Parse data
                Response parsedData = JsonConvert.DeserializeObject<Response>(e.Data);

                // Check if it is a response
                if (parsedData.Header.Type == MessageType.RESPONSE)
                {
                    // Send data to all subscriber
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
