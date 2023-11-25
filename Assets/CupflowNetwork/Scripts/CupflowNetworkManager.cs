using UnityEngine;

namespace CupflowNetwork
{
    public class CupflowNetworkManager : MonoBehaviour
    {
        private void Start()
        {
            try
            {
                int port = Utils.GetActivePort();

                // Show CupflowNetwork connection request modal
                CupflowUIManager.Instance
                    .Modal()
                    .Show(
                        icon: CupflowUIManager.Instance.GetIcons().cupflowLogo,
                        title: "CUPFLOW NETWORK DETECTED",
                        description: "We have detected a running instance of the cupflow network app, do you want to connect to it?",
                        buttons: new ButtonInfo[] {
                            new ButtonInfo(ButtonType.Primary, "CONNECT", (ModalWindow modal) => {
                                WebsocketManager.Instance.Connect(port);
                                modal.Close();
                            }),
                            new ButtonInfo(ButtonType.Primary, "IGNORE", (ModalWindow modal) => {
                                modal.Close();
                            }),
                            new ButtonInfo(ButtonType.Secondary, "DON'T SHOW THIS AGAIN", (ModalWindow modal) => {
                                modal.Close();
                            }),
                        }
                    );
            }
            catch (CupflowNetworkNotOpenException)
            {
                Debug.Log($"[CUPFLOW NETWORK] The Server is not active");
            }

            // Add Listener
            WebsocketManager.Instance.OnWebsocketConnected += OnWebsocketConnected;
        }

        private void OnWebsocketConnected()
        {
            Debug.Log($"[CUPFLOW NETWORK] Websocket Connected");
        }
    }

}
