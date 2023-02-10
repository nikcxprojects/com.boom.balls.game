using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public static Action OnCollided { get; set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.CheckResult();

        OnCollided?.Invoke();
        if (Switcher.VibraEnabled)
        {
            Handheld.Vibrate();
        }
    }
}
