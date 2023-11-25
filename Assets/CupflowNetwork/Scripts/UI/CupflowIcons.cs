using UnityEngine;

namespace CupflowNetwork
{
    [CreateAssetMenu(fileName = "IconSet", menuName = "CupflowNetwork/Private/CupflowIconSet")]
    public class CupflowIconSet : ScriptableObject
    {
        public Sprite cupflowLogo;
        public Sprite error;
        public Sprite warning;
    }
}