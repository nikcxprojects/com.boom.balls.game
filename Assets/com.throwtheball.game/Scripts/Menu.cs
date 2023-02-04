using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.Instance.InitLevel();
            gameObject.SetActive(false);
        });
    }
}
