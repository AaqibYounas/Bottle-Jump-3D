using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsPopUp : MonoBehaviour
{

    public Button musicBTN;
    public Button soundBTN;

    public Sprite musicDisable;
    public Sprite musicEnable;
    public Sprite soundDisable;
    public Sprite soundEnable;

    // Start is called before the first frame update
    void Start()
    {
        if(variables.isMusicON)
            musicBTN.GetComponent<Image>().sprite = musicDisable;
        else
            musicBTN.GetComponent<Image>().sprite = musicEnable;

        if (variables.isSoundON)
            soundBTN.GetComponent<Image>().sprite = soundDisable;
        else
            soundBTN.GetComponent<Image>().sprite = soundEnable;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !FindObjectOfType<HowToPlay>())
            SettingsButtonPress("Back");
    }


    public void SettingsButtonPress(string ID)
    {
        SoundManager.Instance.ButtonClickSound();
   
        switch (ID)
        {
            case "Music":
                print("Music");
                if (variables.isMusicON)
                {
                    musicBTN.GetComponent<Image>().sprite = musicEnable;
                    SoundManager.Instance.MuteMusic();
                }
                else
                {
                    musicBTN.GetComponent<Image>().sprite = musicDisable;
                    SoundManager.Instance.UnMuteMusic();
                }
                break;

            case "Sound":
                print("Sound");
                if (variables.isSoundON)
                {
                    soundBTN.GetComponent<Image>().sprite = soundEnable;
                    SoundManager.Instance.MuteSound();
                }
                else
                {
                    soundBTN.GetComponent<Image>().sprite = soundDisable;
                    SoundManager.Instance.UnMuteSound();
                }
                 break;

            case "Back":
                print("back");
                Destroy(gameObject);
                break;

            case "Privacy Policy":
                //GAManager.Instance.LogDesignEvent("MainMenu:PrivacyPolicy");
                Application.OpenURL("https://rootpointers.com/privacypolicy.html");
                break;

            case "HowToPlay":
                print("HowToPlay");
                Instantiate(Resources.Load(constants.howToPlay));
                break;

        }

    }
}
