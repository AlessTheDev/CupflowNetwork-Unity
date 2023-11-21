using CupflowNetwork;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private Sprite cupflowLogo;
    private void Start()
    {
        WebsocketManager.Instance.OnWebsocketConnected += OnConnection;

        CupflowUIManager.Instance
            .Modal()
            .Show(
                icon: cupflowLogo,
                title: "Modal Title",
                description: "Modal Description",
                buttons: new ButtonInfo[] {
                    new ButtonInfo(ButtonType.Primary, "OK", (ModalWindow modal) => modal.Close())
                }
            );
    }

private void OnConnection()
{
    Debug.Log($"[CUPFLOW NETWORK DEBUG]\nWebsocket Connected");
}
}
