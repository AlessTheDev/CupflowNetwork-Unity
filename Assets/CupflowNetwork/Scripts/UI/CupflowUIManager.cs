using UnityEngine;

namespace CupflowNetwork
{
    public class CupflowUIManager : MonoBehaviour
    {
        public static CupflowUIManager Instance { get; private set; }

        [SerializeField] private Transform windowContainer;

        [SerializeField] private GameObject modalWindow;

        [Header("Icons")]
        [SerializeField] private CupflowIconSet icons;

        private void Awake()
        {
            if (Instance) return;
            Instance = this;
        }

        public ModalWindow Modal()
        {
            ModalWindow modal = Instantiate(modalWindow, windowContainer).GetComponent<ModalWindow>();
            modal.gameObject.SetActive(false);
            return modal;
        }

        public CupflowIconSet GetIcons()
        {
            return icons;   
        }
    }
}

