using UnityEngine.UI;
using UnityEngine;

public class LevelContainer : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Text>().text = $"Level {StatsUtility.Level}";
    }
}
