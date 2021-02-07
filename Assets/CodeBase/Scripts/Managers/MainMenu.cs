using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Analytics;

public class MainMenu : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        //GAManager.Instance.LogDesignEvent("MainMenu:Start");

    }

    public void MenuButtonPress(string ID)
    {
		AnalyticsResult AR = Analytics.CustomEvent("MainMenu : " + ID);
		print(AR.ToString());

        SoundManager.Instance.ButtonClickSound();
        switch (ID)
        {
            case "Play":
                //GAManager.Instance.LogDesignEvent("MainMenu:EndlessMood");
                //variables.gameMood = constants.endless;

                int levelNumber = PlayerPrefs.GetInt(constants.levelCompletedPlayerPrefs);
                if (levelNumber == 0 && levelNumber>=21)
                {
                    levelNumber = 1;
                }
                else
                    levelNumber++;

                variables.currentLevel = levelNumber;
                Application.LoadLevel("Level_"+variables.currentLevel);

                break;

            case "LevelsPlay":
                //GAManager.Instance.LogDesignEvent("MainMenu:LevelMood");
                variables.gameMood = constants.levelBased;
                Instantiate(Resources.Load(constants.levelscreen));
                break;

            case "Settings":
                Instantiate(Resources.Load(constants.settingPath));
		
                break;

            case "RateUS":
                print("RateUs");
                //GAManager.Instance.LogDesignEvent("MainMenu:RateUS");

                Application.OpenURL(constants.storeLink);

                break;
            case "Share":
                //GAManager.Instance.LogDesignEvent("MainMenu:ShareButton");

                StartCoroutine(TakeSSAndShare());
                break;
            case "Twitter":
                //GAManager.Instance.LogDesignEvent("MainMenu:Twitter");

                Application.OpenURL("https://twitter.com/");
                break;

            case "MoreGames":
                //GAManager.Instance.LogDesignEvent("MainMenu:MoreGames");
#if UNITY_ANDROID
                Application.OpenURL("market://search?q=pub:Mass Games Studio");
#endif
                break;
            case "PrivacyPolicy":

                break;
            case "Quit":
                //GAManager.Instance.LogDesignEvent("MainMenu:Quit");

                print("Quit");
                Application.Quit();

                break;

            case "Ads":
                Application.LoadLevel(1);
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

        //new NativeShare().AddFile(filePath).SetSubject("Find Game Here").SetText(constants.gameLink).Share();

        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).SetText( "Hello world!" ).SetTarget( "com.whatsapp" ).Share();
    }

}
