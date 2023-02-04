using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Space(10)]
    [SerializeField] AudioSource loop;
    [SerializeField] Button soundBtn;
    [SerializeField] Image loopIconImg;
    [SerializeField] Sprite loopOn;
    [SerializeField] Sprite loopOff;

    [Space(10)]
    [SerializeField] AudioSource sfx;
    [SerializeField] Button sfxBtn;
    [SerializeField] Image sfxIconImg;
    [SerializeField] Sprite sfxOn;
    [SerializeField] Sprite sfxOff;

    [Space(10)]
    [SerializeField] Button vibroBtn;
    [SerializeField] Image vibroIconImg;
    [SerializeField] Sprite vibroOn;
    [SerializeField] Sprite vibroOff;

    [Space(10)]
    [SerializeField] GameObject optionsPopup;

    public static bool VibraEnable { get; set; } = false;

    private void Start()
    {
        loop.mute = sfx.mute = true;

        soundBtn.onClick.AddListener(() =>
        {
            loop.mute = !loop.mute;

            string status = loop.mute ? "Music Off" : "Music On";
            soundBtn.transform.GetChild(0).GetComponent<Text>().text = $"{status}";

            loopIconImg.sprite = loop.mute ? loopOff : loopOn;
        });


        sfxBtn.onClick.AddListener(() =>
        {
            sfx.mute = !sfx.mute;

            string status = sfx.mute ? "Sounds Off" : "Sounds On";
            sfxBtn.transform.GetChild(0).GetComponent<Text>().text = $"{status}";

            sfxIconImg.sprite = sfx.mute ? sfxOff : sfxOn;
        });

        vibroBtn.onClick.AddListener(() =>
        {
            VibraEnable = !VibraEnable;

            string status = VibraEnable ? "Vibrations On" : "Vibrations Off";
            vibroBtn.transform.GetChild(0).GetComponent<Text>().text = $"{status}";

            vibroIconImg.sprite = VibraEnable ? vibroOn : vibroOff;
        });

        soundBtn.onClick.Invoke();
        sfxBtn.onClick.Invoke();
        vibroBtn.onClick.Invoke();
    }

    public void OpenOptions(bool IsOpen)
    {
        optionsPopup.SetActive(IsOpen);
    }
}
