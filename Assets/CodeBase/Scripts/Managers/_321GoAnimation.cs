using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _321GoAnimation : MonoBehaviour
{
    public Text _321GoText;
    public GameObject pause;
    int numberCount;
    public void afterPause()
    {
        SoundManager.Instance.go321();
        numberCount = 3;
        _321GoText.text = numberCount.ToString();
        _321GoText.transform.localScale = new Vector3(0, 0, 0);
        _321GoText.enabled = true;
        iTween.ScaleTo(_321GoText.gameObject, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 0.6f, "ignoretimescale", true, "oncomplete", "nowTurn", "easetype", iTween.EaseType.easeOutQuad,
    "looptype", iTween.LoopType.loop));
    }
    
    public void nowTurn()
    {
        SoundManager.Instance.go321();
        if (numberCount <=0)
        {
            try
            { iTween.Stop(); }
            catch
            { }
            _321GoText.enabled = false;
            Time.timeScale = 1;
            pause.SetActive(true);
        }
        numberCount--;
        if(numberCount == 0)
            _321GoText.text = "GO";
        else
            _321GoText.text = numberCount.ToString();
    }

}
