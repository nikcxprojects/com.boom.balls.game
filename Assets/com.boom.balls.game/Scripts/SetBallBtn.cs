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
        bool isOpened = transform.parent.GetSiblingIndex() <= StatsUtility.Skins;
        btn.interactable = isOpened;

        GetComponent<Image>().sprite = isOpened ? 
            Resources.Load<Sprite>($"Balls/{transform.parent.GetSiblingIndex()}") : 
            Resources.Load<Sprite>("closed");
    }
}
