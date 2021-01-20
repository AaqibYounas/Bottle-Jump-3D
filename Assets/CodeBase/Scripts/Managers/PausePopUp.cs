using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PausePopUp : MonoBehaviour
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
        SoundManager.Instance.ButtonClickSound();
        Image[] img = GetComponentsInChildren<Image>();

        foreach (Image i in img)
        {
            i.DOFade(0, 0.0000001f);
        }

        foreach (Image i in img)
        {
            i.DOFade(1, 1.5f);
        }


        //Advertisements.Instance.ShowInterstitial();

        Time.timeScale = 0;

        if (variables.isMusicON)
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
        if (Input.GetKeyDown(KeyCode.Escape))
            OnButtonPress("Resume");
    }


    public void OnButtonPress(string str)
    {
        SoundManager.Instance.ButtonClickSound();
        switch (str)
        {
            case "Resume":
                print("Resume");
                //Time.timeScale = 1;
                FindObjectOfType<_321GoAnimation>().afterPause();
                Destroy(gameObject);
                break;

            case "Quit":
                print("Quit");
                Application.Quit();
                break;

            case "MainMenu":
                print("MainMenu");
                Time.timeScale = 1;
                Application.LoadLevel(0);
                break;
            case "Restart":
                print("Restart");
                Time.timeScale = 1;
                Application.LoadLevel(1);
                break;

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


        }
    }


}
