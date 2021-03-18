using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BgPref = "BgPref";
    private static readonly string SePref = "Sepref";

    private int firstPlayInt;
    private float bgFloat, seFloat;

    public Slider bgSlider, seSlider;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            bgFloat = .25f;
            seFloat = .75f;
            bgSlider.value = bgFloat;
            seSlider.value = seFloat;

            PlayerPrefs.SetFloat(BgPref, bgFloat);
            PlayerPrefs.SetFloat(SePref, seFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            bgFloat = PlayerPrefs.GetFloat(BgPref);
            bgSlider.value = bgFloat;

            seFloat = PlayerPrefs.GetFloat(SePref);
            seSlider.value = seFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BgPref, bgSlider.value);
        PlayerPrefs.SetFloat(SePref, seSlider.value);
    }

    private void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }
}
