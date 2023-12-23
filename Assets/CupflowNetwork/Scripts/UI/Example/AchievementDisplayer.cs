using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CupflowNetwork
{
    public class AchievementDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI achievementName;
        [SerializeField] private TextMeshProUGUI achievementDescription;
        [SerializeField] private Image achievementImage;

        public void Display(Achievement achievement)
        {
            achievementName.text = achievement.name;
            achievementDescription.text = achievement.description;
            StartCoroutine(Utils.AssignUrlToImage(achievementImage, achievement.image));
        }
    }
}

