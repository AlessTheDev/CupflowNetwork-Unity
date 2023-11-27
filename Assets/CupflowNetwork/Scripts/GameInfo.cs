using UnityEngine;

namespace CupflowNetwork
{
    [CreateAssetMenu(fileName = "GameInfo", menuName = "CupflowNetwork/GameInfo")]
    public class GameInfo : ScriptableObject
    {
        public string GameId;
        public string GameSecret;
    }
}