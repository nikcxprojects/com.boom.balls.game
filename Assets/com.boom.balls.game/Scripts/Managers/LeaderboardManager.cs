using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] Transform container;

    private void OnEnable() => UpdateBoard();

    public void UpdateBoard()
    {
        foreach(Transform t in container)
        {
            t.gameObject.SetActive(false);
        }

        int[] scores = new int[container.childCount];
        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = Random.Range(250, 800);
        }

        var sortedScores = scores.OrderByDescending(i => i).ToArray();
        for(int i = 0; i < container.childCount; i++)
        {
            Text leader = container.GetChild(i).GetChild(0).GetComponent<Text>();
            leader.text = $"{sortedScores[i]}";
        }

        StartCoroutine(nameof(EnableItems));
    }

    IEnumerator EnableItems()
    {
        foreach (Transform t in container)
        {
            yield return new WaitForSeconds(1);
            t.gameObject.SetActive(true);
        }
    }
}
