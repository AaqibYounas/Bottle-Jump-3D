using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Revive : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private float totalTime;

    [SerializeField] private ITweenMagic tween;


    float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = totalTime;
    }

    IEnumerator delayReviveSound()
    {
        yield return new WaitForSeconds(1);
        SoundManager.Instance.revive();
    }


    // Update is called once per frame
    void Update()
    {
       if(timeLeft>0)
        {
            timeLeft -= Time.deltaTime;
            fillImage.fillAmount = timeLeft / totalTime;
        }
       else
        {
            print("timeOver");
            tween.enabled = true;
        }
    }
    public void destoryRevive()
    {
        if(variables.gameMood == constants.endless)
            Instantiate(Resources.Load(constants.gameOverPath));
        else
            Instantiate(Resources.Load(constants.LevelGameOver));
        Destroy(gameObject);
    }



    public void rewardedVideoBTN()
    {
        /// For testing purpose 
        /// 
        //FindObjectOfType<GameManager>().Revive();
        //Destroy(gameObject);



        //if (Advertisements.Instance.IsRewardVideoAvailable())
        //{
        //    Destroy(gameObject);
        //    Advertisements.Instance.ShowRewardedVideo(completedAd);
        //}
        ////print("Video");
        ////FindObjectOfType<GameoverManager>().reviveDrop();
    }

    public void completedAd(bool completed)
    {
        if (completed)
        {
            //FindObjectOfType<GameManager>().Revive();
        }
    }

}
