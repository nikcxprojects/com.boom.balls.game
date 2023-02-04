using UnityEngine;
using UnityEngine.UI;

public class ScoreContainer : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Text>().text = $"{StatsUtility.Score}";
    }
}
