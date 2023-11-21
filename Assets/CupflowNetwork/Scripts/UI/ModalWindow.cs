using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CupflowNetwork
{
    public class ModalWindow : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private Transform buttonsContainer;

        [Header("Prefabs")]
        [SerializeField] private ModalButton modalButton;

        public void Show(Sprite icon, string title = null, string description = null, ButtonInfo[] buttons = null)
        {
            // Hide all the fields
            iconImage.gameObject.SetActive(false);
            titleText.gameObject.SetActive(false);
            descriptionText.gameObject.SetActive(false);
            buttonsContainer.gameObject.SetActive(false);

            iconImage.sprite = icon;

            if (title != null)
            {
                titleText.gameObject.SetActive(true);
                titleText.text = title;
            }

            if(description != null)
            {
                descriptionText.gameObject.SetActive(true);
                descriptionText.text = description;
            }

            if(buttons != null)
            {
                buttonsContainer.gameObject.SetActive(true);
                foreach (ButtonInfo info in buttons)
                {
                    ModalButton button = Instantiate(modalButton, buttonsContainer).GetComponent<ModalButton>();
                    button.AssignModal(this); 
                    button.Init(info);
                }
            }
            gameObject.SetActive(true);
        }

        public void Close()
        {
            Destroy(gameObject);
        }
    }
}

