using CupflowNetwork;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CupflowHome : MonoBehaviour
{
    [Header("Home Settings")]
    [SerializeField] private TextMeshProUGUI username;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image pfp;
    [SerializeField] private Image backgroundImage;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        new UserProfileRequest(
            OnResponse: (userProfile) =>
            {
                AssignHomeData(userProfile);
            },
            OnError: (error) =>
            {
                CupflowUIManager.Instance
                .Modal()
                .Show(
                    icon: CupflowUIManager.Instance.GetIcons().error,
                    title: "ERROR while fetching the profile",
                    description: $"Error message: {error}",
                    buttons: new ButtonInfo[] {
                            new ButtonInfo(ButtonType.Secondary, "CLOSE", (ModalWindow modal) => {
                                modal.Close();
                            })
                    }
                );
            }
        ).SendRequest();
    }

    private void AssignHomeData(UserProfile profile)
    {
        username.text = profile.username;
        description.text = profile.description;

        StartCoroutine(Utils.AssignUrlToImage(pfp, profile.pfpLink));
        StartCoroutine(Utils.AssignUrlToImage(backgroundImage, profile.backgroundLink));
    }
}
