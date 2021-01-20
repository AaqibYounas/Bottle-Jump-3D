﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GameOver : MonoBehaviour
{
    public Text currentScore;
    public Text bestScore,score;
    public GameObject current, newRecord;

    // Start is called before the first frame update
    void Start()
    {

        Image[] img= GetComponentsInChildren<Image>();

        foreach (Image i in img)
        {
            i.DOFade(1, 1.5f);
        }

        if (variables.gameMood == constants.levelBased)
        {
            bestScore.text = "Level " + (variables.currentLevel+1).ToString() + " Failed";
            current.SetActive(false);
            newRecord.SetActive(false);
        }
        else
        {
            score.text = variables.currentScore.ToString();
            int best = PlayerPrefs.GetInt(constants.bestScorePlayerPrefs);

            if (best < variables.currentScore)
            {
                bestScore.text = variables.currentScore.ToString();
                PlayerPrefs.SetInt(constants.bestScorePlayerPrefs, variables.currentScore);
            }
            else
            {
                bestScore.text = best.ToString();
            }

        }
    }

    // Update is called once per frame
    public void MenuButtonPress(string ID)
    {
        //Advertisements.Instance.ShowInterstitial();
        SoundManager.Instance.ButtonClickSound();
        switch (ID)
        {
            case "Restart":
                //GAManager.Instance.LogDesignEvent("GameOver:score " + variables.currentScore);
                SoundManager.Instance.VolumeUp();
                //Advertisements.Instance.ShowInterstitial();

                Time.timeScale = 1;

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
                        Application.LoadLevel(1);
                    }
                }
                else
                {
                    Application.LoadLevel(1);
                }

                break;

            case "Home":
                //GAManager.Instance.LogDesignEvent("GameOver:Home");
                //Advertisements.Instance.ShowInterstitial();
                SoundManager.Instance.buttonClick();
                SoundManager.Instance.VolumeUp();
                Time.timeScale = 1;
                Application.LoadLevel(0);
                break;

            case "Share":
                //GAManager.Instance.LogDesignEvent("GameOver:Share");
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

        new NativeShare().AddFile(filePath).SetSubject("Game").SetText("Can you beat My Score " + constants.gameLink ).Share();


    }

}
