using UnityEngine.UI;
using UnityEngine;

public class LevelContainer : MonoBehaviour
{
    private const int max = 100;

    [SerializeField] Text missionText;
    [SerializeField] Text detailsText;
    [SerializeField] Text countText;

    private void OnEnable()
    {
        missionText.text = $"MISSION {StatsUtility.Level}/{max}";
        detailsText.text = $"Score {StatsUtility.Level} point";
        countText.text = $"{StatsUtility.LevelProgress}/{StatsUtility.Level}";
    }
}
