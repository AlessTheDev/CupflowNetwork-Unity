using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CupflowNetwork
{
    public class CupflowUIManager : MonoBehaviour
    {
        public static CupflowUIManager Instance { get; private set; }

        [SerializeField] private GameObject modalWindow;

        private void Awake()
        {
            if (Instance) return;
            Instance = this;
        }

        public ModalWindow Modal()
        {
            ModalWindow modal = Instantiate(modalWindow, transform).GetComponent<ModalWindow>();
            modal.gameObject.SetActive(false);
            return modal;
        }
    }
}

