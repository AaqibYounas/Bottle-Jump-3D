using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject playerObj;
    //void Start()
    //{
    //    Time.timeScale = 0;
    //    iTween.ScaleTo(cube, iTween.Hash("scale", new Vector3(3, 3, 3), "speed", 1, "ignoretimescale", true, "oncomplete", "nowTurnON", "easetype", "linear",
    //        "looptype", iTween.LoopType.loop));
    //}

    //Vector3 targetScale = new Vector3(4, 4, 4);
    //void nowTurnON()
    //{
    //    print("Okay");
    //    iTween.Stop();

    //    //iTween.ValueTo(this.gameObject, iTween.Hash("from", GetComponent<Transform>().localScale, "to", targetScale, "time", 1,
    //    //    "looptype", iTween.LoopType.none, "onupdate", "ScaleObject", "oncomplete", "OnScaleTweenCompleted", "easetype", iTween.EaseType.linear));
    //}
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rotateAndPosition();
            print("space");
        }
    }


    public void rotateAndPosition()
    {
        switch (playerObj.name)
        {
            case "J 1":
                iTween.RotateAdd(playerObj, new Vector3(0, 0, -90.1f), 0.2f);
                iTween.MoveTo(playerObj, iTween.Hash("position", new Vector3(0, -0.5021f, 0), "islocal", false, "time", 1)); 

                playerObj.name = "J 2";
                break;
            case "J 2":
                iTween.RotateAdd(playerObj, new Vector3(0, 0, -90.1f), 0.2f);
                playerObj.name = "J 3";
                break;
            case "J 3":
                iTween.RotateAdd(playerObj, new Vector3(0, 0, -90.1f), 0.2f);
                playerObj.name = "J 4";
                break;
            case "J 4":
                iTween.RotateAdd(playerObj, new Vector3(0, 0, -90.1f), 0.2f);
                iTween.MoveTo(playerObj, iTween.Hash("position", new Vector3(0, +0.5021f, 0), "islocal", false, "time", 1));
                //wait(true);
                playerObj.name = "J 1";
                break;
        }
    }


}
