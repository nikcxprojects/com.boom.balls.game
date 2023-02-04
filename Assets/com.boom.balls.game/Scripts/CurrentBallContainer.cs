using UnityEngine.UI;
using UnityEngine;

public class CurrentBallContainer : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>($"Balls/{StatsUtility.CurrentBall}");
    }
}
