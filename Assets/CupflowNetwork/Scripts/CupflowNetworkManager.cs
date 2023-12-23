using System.Threading.Tasks;
using UnityEngine;

namespace CupflowNetwork
{
    public class CupflowNetworkManager : MonoBehaviour
    {
        [SerializeField] private GameInfo gameInfo;

        public static CupflowNetworkManager Instance { get; private set; }

        private Achievement[] gameAchievements = null;

        private void Start()
        {
            if (Instance != null)
            {
                Debug.LogError("There are 2 instances of the Cupflow Network Manager");
                return;
            }

            Instance = this;

            if (gameInfo == null)
            {
                Debug.LogError("Game info can't be null");
            }

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

            AddGame();
            FetchAchievements();
        }

        private void AddGame()
        {
            new AddGameRequest(
                OnResponse: (_) => { },
                OnError: (_) => { },
                new AddGameRequestParams(gameInfo.GameId, gameInfo.GameSecret)
            ).SendRequest();
        }

        private async void FetchAchievements()
        {
            System.Diagnostics.Stopwatch s = System.Diagnostics.Stopwatch.StartNew();
            await Task.Run(() =>
            {
                s.Start();
                new GetGameAchievementsRequest(
                OnResponse: (data) =>
                {
                    gameAchievements = data;
                    s.Stop();
                },
                OnError: (e) => { Debug.LogError($"[CUPFLOW NETWORK] Error while getting Game Achievements: {e}"); },
                new GetGameAchievementsParams(gameInfo.GameId)
                ).SendRequest();
            });

            Debug.Log($"The operation took: {s.ElapsedMilliseconds}");
        }

        public Achievement[] GetGameAchievements()
        {
            return gameAchievements;
        }
    }

}
