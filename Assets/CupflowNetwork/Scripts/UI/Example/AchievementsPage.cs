using CupflowNetwork;
using System.Collections;
using System.Linq;
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
        StartCoroutine(ShowAchievements(CupflowNetworkManager.Instance.GetGameAchievements()));
    }

    private IEnumerator ShowAchievements(Achievement[] achievements)
    {
        error.gameObject.SetActive(false);

        string[] obtainedAchievementsIds = null;

        new GetObtainedAchievementsIdsRequest(
            OnResponse: (data) => obtainedAchievementsIds = data,
            OnError: (e) =>
            {
                Debug.LogError($"[CUPFLOW NETWORK] Error while fetching obtained achievement: {e}");
                error.gameObject.SetActive(true);
                error.text = e;
            }
        ).SendRequest();
        yield return new WaitWhile(() => obtainedAchievementsIds == null);
        DestroyAllChildren(achievementsContainer);

        foreach (Achievement achievement in achievements)
        {
            AchievementDisplayer newAchievement = Instantiate(achievementDisplay.gameObject, achievementsContainer).GetComponent<AchievementDisplayer>();

            newAchievement.Display(achievement);

            newAchievement.SetIsObtained(obtainedAchievementsIds.Contains(achievement.id));
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
