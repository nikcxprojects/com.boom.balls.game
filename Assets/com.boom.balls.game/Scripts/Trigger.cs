using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public static Action OnCollided { get; set; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.CheckResult();

        OnCollided?.Invoke();
        if(Switcher.VibraEnabled)
        {
            Handheld.Vibrate();
        }
    }
}
