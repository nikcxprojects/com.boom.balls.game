using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkinProgress : MonoBehaviour
{
    public static SkinProgress Instance { get=> FindObjectOfType<SkinProgress>(); }

    [SerializeField] Image progressAmount;
    private const float max = 100;

    private void OnEnable()
    {
        UpdateProgress();
    }

    public void UpdateProgress(int amount = 0)
    {
        StatsUtility.SkinProgress += amount;
        progressAmount.fillAmount = StatsUtility.SkinProgress / max;

        if (StatsUtility.SkinProgress >= max)
        {
            ++StatsUtility.Skins;
            StatsUtility.SkinProgress = 0;

            progressAmount.fillAmount = StatsUtility.SkinProgress / max;
            StartCoroutine(nameof(ShowMessage));
        }
    }

    private IEnumerator ShowMessage()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 0.75f));
        Destroy(Instantiate(Resources.Load<GameObject>("new skin"), null), 1.0f);
    }
}
