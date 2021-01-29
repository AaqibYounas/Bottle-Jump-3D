using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameplayUIHandler : MonoBehaviour {

    public Image levelbar;
    public GameObject start, end, bottle;
    public Text levelIndicator1, levelIndicator2;
    public float levelCompletionPercentatge;
    private float bottleDistance, totalDistance;
    public GameManager Manager;
    public GameObject PausePanel;
    public GameObject GameOverPanel;

    public AudioSource clickSound;

    public bool isBottleFlip = false;

    public Text TotalCoinsText;

    public GameObject MainMenu;
    public GameObject GameplayUI;

    public GameManager gameManager;
    // Use this for initialization
    void Awake () 
    {
        this.gameManager = GameManager.GetInstance();
        //this.TotalCoinsText.text = PrefsManager.GetTotalCoins().ToString();
        this.Manager = GameManager.GetInstance();
        gameStarter();
	}
    
    public void StartGame()
    {
        this.MainMenu.SetActive(false);
        this.StartG();
        
    }

    void StartG()
    {
        this.GameplayUI.SetActive(true);
        GameManager.CanSpawnHurdle = true;
       // this.gameManager.PlayerController.enabled = true;
    }
    public void levelBarUpdater()
    {
        bottleDistance = end.transform.position.z - bottle.transform.position.z;
        float coveredDistance = totalDistance - bottleDistance;
        levelbar.fillAmount = coveredDistance / totalDistance;
        levelCompletionPercentatge = (coveredDistance / totalDistance) * 100;
        //print(coveredDistance/totalDistance);

    }
    private void gameStarter()
    {
        variables.isLevelComplete = false;
        start = GameObject.Find("Start");
        end = GameObject.Find("End");
        bottle = GameObject.FindGameObjectWithTag("Player");
        start.transform.position = bottle.transform.position;
        totalDistance = end.transform.position.z - start.transform.position.z;
        print(totalDistance);
        levelIndicator1.text = variables.currentLevel.ToString();
        levelIndicator2.text = (variables.currentLevel + 1).ToString();
    }


    // Update is called once per frame
    void Update () 
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            this.HomeButton();
        }

        levelBarUpdater();
        //if (Input.GetMouseButtonDown(0))
        //{
        //    this.StartGame();
        //}
	}

    public void OnShareButton()
    {
        Application.OpenURL("https://www.facebook.com/");
    }

    public void OnLikeButton()
    {
        Application.OpenURL("https://www.facebook.com/hadid.ali");
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("1-MainMenu");
    }

    public void RestartButtonLevel()
    {
        this.Manager.RestartGame();
    }

    public void PauseButton()
    {
        this.Manager.PauseGame();
    }

    public void UnPauseButton()
    {
        this.Manager.UnPauseGame();
    }

    public void OnClickBottleFlip()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("4-BottleFlip");
    }

    public void OnClickDumpTheBall()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("5-DumpTheBall");
    }

    public void OnClickBack()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("1-MainMenu");
    }


    public void OnStore()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        if (isBottleFlip)
        {
            Store.backScene = "4-BottleFlip";
        }
        else
        {
            Store.backScene = "5-DumpTheBall";
        }
        SceneManager.LoadScene("2-Store");

        //if (Chartboost.hasInterstitial(CBLocation.Static))
        //{
        //    Chartboost.showInterstitial(CBLocation.Static);
        //}
        //else
        //{
        //    Debug.Log("cb Pangay no MainMenu");
        //    GameObject.Find("AdMob").GetComponent<GoogleMobileAdsDemoScript>().ShowInterstitial();
        //    Chartboost.cacheInterstitial(CBLocation.Static);
        //}
        //Store.SetActive(true);
    }

    public void OnClickStats()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("3-Stats");

        //if (Chartboost.hasInterstitial(CBLocation.Static))
        //{
        //    Chartboost.showInterstitial(CBLocation.Static);
        //}
        //else
        //{
        //    Debug.Log("cb Pangay no MainMenu");
        //    GameObject.Find("AdMob").GetComponent<GoogleMobileAdsDemoScript>().ShowInterstitial();
        //    Chartboost.cacheInterstitial(CBLocation.Static);
        //}
        //Store.SetActive(true);
    }

    public void PlayClickSound()
    {
        print("Sound");
        //if (!clickSound.isPlaying)
        //{
        //    clickSound.Play();
        //}
    }

    public void OnRateUs()
    {
        Application.OpenURL("play.google.com");
    }
}
