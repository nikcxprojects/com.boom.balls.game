using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private GameObject LevelPrefab { get; set; }
    private Transform Parent { get; set; }

    [SerializeField] GameObject game;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject pause;

    [Space(10)]
    [SerializeField] GameObject leaderboard;

    [Space(10)]
    [SerializeField] GameObject skins;
    [SerializeField] Transform rootSkins;
    public Transform arrow;

    [Space(10)]
    [SerializeField] GameObject currentBall;

    [Space(10)]
    [SerializeField] Text scoreText;

    private void Awake()
    {
        LevelPrefab = Resources.Load<GameObject>("level");
        Parent = GameObject.Find("Environment").transform;

        OpenMenu();
    }

    private void Start()
    {
        Transform skin = rootSkins.GetChild(StatsUtility.CurrentBall);
        arrow.position = new Vector2(skin.position.x, skin.position.y - 0.5f);
    }

    public void InitLevel()
    {
        Instantiate(LevelPrefab, Parent);
        if(!game.activeSelf)
        {
            OpenGame();
        }
    }

    public void CheckResult()
    {
        StartCoroutine(nameof(ShowMessage));
        SkinProgress.Instance.UpdateProgress(1);

        StatsUtility.Score++;
        StatsUtility.LevelProgress++;
        if(StatsUtility.LevelProgress >= StatsUtility.Level)
        {
            StatsUtility.LevelProgress = 0;
            StatsUtility.Level++;
        }

        scoreText.text = $"{StatsUtility.Score}";
    }

    public void OpenMenu()
    {
        if (FindObjectOfType<Level>())
        {
            Destroy(FindObjectOfType<Level>().gameObject);
        }

        StatsUtility.BestScore = StatsUtility.Score;

        game.SetActive(false);
        pause.SetActive(false);

        menu.SetActive(true);
        skins.SetActive(false);
    }

    public void OpenGame()
    {
        StatsUtility.Score = 0;
        scoreText.text = $"{StatsUtility.Score}";

        game.SetActive(true);
        menu.SetActive(false);

        skins.SetActive(false);
    }

    public void OpenSkins(bool IsOpened)
    {
        skins.SetActive(IsOpened);
        currentBall.SetActive(!IsOpened);
    }

    public void OpenLeaderboard(bool IsOpened) => leaderboard.SetActive(IsOpened);

    public void OpenSetings(bool IsOpened) => settings.SetActive(IsOpened);

    public void OpenPause(bool IsPause) => pause.SetActive(IsPause);

    private IEnumerator ShowMessage()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 0.75f));
        Destroy(Instantiate(Resources.Load<GameObject>("nice"), null), 1.0f);
    }
}