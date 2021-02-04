using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverLevel : MonoBehaviour
{
    public Text LevelText;
   
    // Start is called before the first frame update
    void Start()
    {
        Image[] img = GetComponentsInChildren<Image>();

        foreach (Image i in img)
        {
            i.DOFade(1, 1.5f);
        }

        LevelText.text = "Level " + (variables.currentLevel).ToString() + " Failed";


        SoundManager.Instance.levelFail();
    }

    // Update is called once per frame
    public void MenuButtonPress(string ID)
    {
        //SoundManager.Instance.ButtonClickSound();
        if (variables.currentLevel % 2 == 0)
        {
            print("Ad");
        }


        switch (ID)
        {

            case "Restart":
                //GAManager.Instance.LogDesignEvent("GameOver:Start_Level "+variables.currentLevel);
                SoundManager.Instance.VolumeUp();

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
                        Application.LoadLevel("Level_" + (variables.currentLevel));
                    }
                }
                else
                {
                    Application.LoadLevel("Level_" + (variables.currentLevel));
                }

                break;

            case "Home":
                //GAManager.Instance.LogDesignEvent("GameOver:Home");
                SoundManager.Instance.buttonClick();
                SoundManager.Instance.VolumeUp();
                Time.timeScale = 1;
                Application.LoadLevel(0);
                break;

            case "Share":
                //GAManager.Instance.LogDesignEvent("GameOver:Share");

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
