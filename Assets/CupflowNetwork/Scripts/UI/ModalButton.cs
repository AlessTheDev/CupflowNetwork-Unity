using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CupflowNetwork
{
    public enum ButtonType
    {
        Primary,
        Secondary,
        Danger
    }
    public class ButtonInfo
    {
        public ButtonType ButtonType { get; private set; }
        public string Text { get; private set; }
        public UnityAction<ModalWindow> OnCLick { get; private set; }

        public ButtonInfo(ButtonType type, string text, UnityAction<ModalWindow> onClick)
        {
            this.ButtonType = type;
            this.Text = text;
            this.OnCLick = onClick;
        }
    }
    public class ModalButton : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image buttonBackground;

        private UnityAction<ModalWindow> OnButtonClicked;
        private ModalWindow modal;

        public void Init(ButtonInfo buttonInfo)
        {
            switch (buttonInfo.ButtonType)
            {
                case ButtonType.Primary:
                    buttonBackground.color = new Color32(240, 235, 216, 255);
                    break;
                case ButtonType.Secondary:
                    buttonBackground.color = new Color32(20, 21, 26, 255);
                    text.color = Color.white; 
                    break;
                case ButtonType.Danger:
                    buttonBackground.color = new Color32(245, 115, 115, 255);
                    break;

            }
            // Assign On Click event
            OnButtonClicked = buttonInfo.OnCLick;

            // Assign text
            text.text = buttonInfo.Text;
        }

        public void Clicked()
        {
            OnButtonClicked(modal);
        }

        public void AssignModal(ModalWindow modal)
        {
            this.modal = modal; 
        }
    }
}