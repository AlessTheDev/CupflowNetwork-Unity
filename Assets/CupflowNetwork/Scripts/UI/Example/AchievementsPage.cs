using CupflowNetwork;
using TMPro;
using UnityEngine;

public class AchievementsPage : MonoBehaviour
{
    [SerializeField] private AchievementDisplayer achievementDisplay;
    [SerializeField] private TextMeshProUGUI error;
    [SerializeField] private Transform achievementsContainer;

    private void OnEnable()
    {
        error.gameObject.SetActive(false);  
        ShowAchievements(CupflowNetworkManager.Instance.GetGameAchievements());
    }

    private void ShowAchievements(Achievement[] achievements)
    {
        DestroyAllChildren(achievementsContainer);

        foreach(Achievement achievement in achievements)
        {
            AchievementDisplayer newAchievement = Instantiate(achievementDisplay.gameObject, achievementsContainer).GetComponent<AchievementDisplayer>();

            newAchievement.Display(achievement);
        }
    }

    private void DestroyAllChildren(Transform parent)
    {
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            // Destroy the child game object
            Destroy(parent.GetChild(i).gameObject);
        }
    }
}
