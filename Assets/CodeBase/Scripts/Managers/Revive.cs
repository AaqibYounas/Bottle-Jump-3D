using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Revive : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private float totalTime;
    [SerializeField] private Text levelPercentage;

    [SerializeField] private ITweenMagic tween;
    public Text time;

    float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = totalTime;
        levelPercentage.text = ( FindObjectOfType<GameplayUIHandler>().levelCompletionPercentatge + "% " + "Level Completed").ToString();
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
            time.text = ((timeLeft+1) .ToString())[0].ToString();
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
        //FindObjectOfType<GameManager>().revive();
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
