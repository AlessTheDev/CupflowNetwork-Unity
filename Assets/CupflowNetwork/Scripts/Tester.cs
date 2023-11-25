using CupflowNetwork;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private Sprite cupflowLogo;
    private void Start()
    {
        WebsocketManager.Instance.OnWebsocketConnected += OnConnection;
        //WebsocketManager.Instance.OnWebsocketResponse += OnResponse;
    }

    private void OnResponse(Response res)
    {
        Debug.Log($"[CUPFLOW NETWORK DEBUG]\nResponse data: {res.Body.Data}");
    }

    private void OnConnection()
    {
        //Debug.Log($"[CUPFLOW NETWORK DEBUG]\nWebsocket Connected");

        
    }
}
