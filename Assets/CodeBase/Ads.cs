using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ads : MonoBehaviour
{
    public Text txt;


    public void intersitialAds()
    {
        if(!Advertisements.Instance.IsInterstitialAvailable())
        {
            txt.text = "Ad is not loaded ";
            Advertisements.Instance.GetInterstitialAdvertisers();

        }
        else
        {
            Advertisements.Instance.ShowInterstitial();

        }
    }
    public void rewardedAds()
    {
        if(!Advertisements.Instance.IsRewardVideoAvailable())
        {
            txt.text = "Videp is not loaded ";
            Advertisements.Instance.GetRewardedAdvertisers();

        }
        else
        {
            Advertisements.Instance.ShowRewardedVideo(award);
        }
    }
    
    public void award(bool A)
    {
        if (A)
        {
            txt.text = "you got award:";
        }
        else
            txt.text = "you skiped award:";

    }


}
