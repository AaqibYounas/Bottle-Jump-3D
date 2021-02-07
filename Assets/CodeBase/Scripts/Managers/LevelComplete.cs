﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Analytics;

public class LevelComplete : MonoBehaviour
{

    private void Awake()
    {

    }
    public Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        Image[] img = GetComponentsInChildren<Image>();

        foreach (Image i in img)
        {
            i.DOFade(1, 1.5f);
        }

		AnalyticsResult AR = Analytics.CustomEvent("LevelCompleted : " + variables.currentLevel );
		print (AR.ToString ());
		//GAManager.Instance.LogDesignEvent("LevelComplete:Start");


        levelText.text = "Level " + (variables.currentLevel).ToString() + " Complete";
        SoundManager.Instance.levelComplete();
        PlayerPrefs.SetInt(constants.levelCompletedPlayerPrefs, variables.currentLevel);
    }

    public void MenuButtonPress(string ID)
    {
		AnalyticsResult AR = Analytics.CustomEvent("LevelCompleted : " + ID );
		print (AR.ToString ());
        
		if (variables.currentLevel % 2 == 0)
        {
            print("Show Ad");
            //Advertisements.Instance.ShowInterstitial();
        }
        else
            print("NOT showing");

        switch (ID)
        {
            case "Restart":
                //GAManager.Instance.LogDesignEvent("LevelComplete:ButtonPress");
                //SoundManager.Instance.VolumeUp();
                //Advertisements.Instance.ShowInterstitial();

                if (PlayerPrefs.GetInt(constants.rateusUsedPlayerPrefs) == 0)
                {
                    if (!PlayerPrefs.HasKey(constants.rateusPlayerPrefs))
                    {
                        PlayerPrefs.SetInt(constants.rateusPlayerPrefs, 1);
                    }

                    int N = PlayerPrefs.GetInt(constants.rateusPlayerPrefs);

                    if (N % 3 == 0)
                    {
                        Instantiate(Resources.Load(constants.rateUS));
                    }
                    else
                    {
                        PlayerPrefs.SetInt(constants.rateusPlayerPrefs, ++N);
                        Application.LoadLevel("Level_" + (variables.currentLevel));
                    }
                }
                else
                {
                    Application.LoadLevel("Level_" + (variables.currentLevel));
                }

                break;

            case "Home":
                //GAManager.Instance.LogDesignEvent("LevelComplete:Home");
                //Advertisements.Instance.ShowInterstitial();
                SoundManager.Instance.buttonClick();
                Time.timeScale = 1;
                Application.LoadLevel(0);
                break;

            case "NextLevel":
                //GAManager.Instance.LogDesignEvent("LevelComplete:Next");
                //Advertisements.Instance.ShowInterstitial();
                variables.currentLevel++;

                if (variables.currentLevel >= 21)
                    variables.currentLevel = 1;

                SoundManager.Instance.buttonClick();
                Application.LoadLevel("Level_" + (variables.currentLevel));
                break;

            case "Share":
                //GAManager.Instance.LogDesignEvent("LevelComplete:Share");
                //Advertisements.Instance.ShowInterstitial();

                StartCoroutine(TakeSSAndShare());
                print("ShareNative");

                break;

        }
    }
    private IEnumerator TakeSSAndShare()
    {
        yield return new WaitForEndOfFrame();
        //GAManager.Instance.LogDesignEvent("Share:NativeShare");

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        //new NativeShare().AddFile(filePath).SetSubject("Game").SetText("Can you beat My Level " + constants.gameLink ).Share();


    }

}
