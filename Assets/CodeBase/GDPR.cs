using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GDPR : MonoBehaviour {
    public GameObject gdprBG;
    public Text country;

    public Button btn;
    void Awake()
    {

        //PlayerPrefs.DeleteAll();
    }
	void Start () 
    {
        if (Advertisements.Instance.UserConsentWasSet() == false)
        {
            // gdprBG.SetActive(true);
            Advertisements.Instance.SetUserConsent(true);

        }
        else
        {
            Advertisements.Instance.Initialize();
            //GAManager.Instance.LogDesignEvent("Ads:initialize");
        }

    }

    public void personal()
    {
        gdprBG.SetActive(false);
        //Advertisements.Instance.SetUserConsent(true);
    }

    public void random()
    {
        gdprBG.SetActive(false);
        //Advertisements.Instance.SetUserConsent(false);
    }

    public void intersitial()
    {
        //Advertisements.Instance.ShowInterstitial();
    }


    public void isloaded()
    {
        //if (Advertisements.Instance.IsRewardVideoAvailable())
        //{
        //   btn.transform.GetChild(0).GetComponent<Text>().text = "Load";
        //}

    }

}
