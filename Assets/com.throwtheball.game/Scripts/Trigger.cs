using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public static Action OnCollided { get; set; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float distance = Mathf.Abs(collision.transform.position.x - transform.position.x);
        GameManager.Instance.CheckResult(distance);

        OnCollided?.Invoke();
        if(SettingsManager.VibraEnable)
        {
            Handheld.Vibrate();
        }
    }
}
