using UnityEngine;

public class Ball : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"Balls/{StatsUtility.CurrentBall}");
    }
}
