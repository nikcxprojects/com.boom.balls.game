using UnityEngine.UI;
using UnityEngine;

public class CuteBtn : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if(FindObjectOfType<Level>()!= null)
            {
                FindObjectOfType<Level>().Cute();
            }
        });
    }
}
