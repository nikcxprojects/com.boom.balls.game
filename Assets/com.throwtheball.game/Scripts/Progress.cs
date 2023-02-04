using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public static Progress Instance { get => FindObjectOfType<Progress>(); }

    private const float max = 10;

    [SerializeField] Text currentLevelCount;
    [SerializeField] Text nextLevelCount;

    [Space(10)]
    [SerializeField] Image progressImgAmount;

    private void Start()
    {
        currentLevelCount.text = $"{StatsUtility.Level}";
        nextLevelCount.text = $"{StatsUtility.Level + 1}";

        UpdateProgress();
    }

    public void UpdateProgress(int amount = 0)
    {
        StatsUtility.LevelProgress += amount;
        progressImgAmount.fillAmount = StatsUtility.LevelProgress / max;

        if(StatsUtility.LevelProgress >= max)
        {
            ++StatsUtility.Level;
            StatsUtility.LevelProgress = 0;

            currentLevelCount.text = $"{StatsUtility.Level}";
            nextLevelCount.text = $"{StatsUtility.Level + 1}";

            progressImgAmount.fillAmount = StatsUtility.LevelProgress / max;
            StartCoroutine(nameof(ShowMessage));
        }
    }

    private IEnumerator ShowMessage()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 0.75f));
        Destroy(Instantiate(Resources.Load<GameObject>("new level"), null), 1.0f);
    }
}
