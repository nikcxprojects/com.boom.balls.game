using UnityEngine.UI;
using UnityEngine;

public class BestScoreContainer : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Text>().text = $"{StatsUtility.BestScore}";
    }
}
