using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] Button startBtn;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        startBtn.onClick.AddListener(() =>
        {
            GameManager.Instance.InitLevel();
            gameObject.SetActive(false);
        });
    }
}
