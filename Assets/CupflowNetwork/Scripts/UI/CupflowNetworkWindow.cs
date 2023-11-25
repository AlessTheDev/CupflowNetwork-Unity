using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CupflowNetwork
{
    public class CupflowNetworkWindow : MonoBehaviour
    {
        [Header("Windows")] 
        [SerializeField] private GameObject home;

        public void ShowHome()
        {
            home.SetActive(true);
        }
    }
}

