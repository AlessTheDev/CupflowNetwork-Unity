using UnityEngine;

namespace CupflowNetwork
{
    public class CupflowNetworkManager : MonoBehaviour
    {
        private void Start()
        {
            WebsocketManager.Instance.OnWebsocketConnected += OnWebsocketConnected;
        }

        private void OnWebsocketConnected()
        {

        }
    }

}
