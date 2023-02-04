using UnityEngine;
using UnityEngine.UI;

public class SetBallBtn : MonoBehaviour
{
    Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            StatsUtility.CurrentBall = transform.parent.GetSiblingIndex();
            GameManager.Instance.arrow.position = new Vector2(btn.transform.position.x, btn.transform.position.y - 0.5f);
        });
    }

    private void OnEnable()
    {
        btn.interactable = transform.parent.GetSiblingIndex() <= StatsUtility.Skins;
    }
}
