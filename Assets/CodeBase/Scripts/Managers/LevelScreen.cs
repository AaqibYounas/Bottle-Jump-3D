using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScreen : MonoBehaviour
{

    public Sprite img, img1, img2, img3;
    public Sprite _img, _img1, _img2, _img3;

    public GameObject obj;
    public Transform parent;

    void Start()
    {
        createButtons();
    }

    private void createButtons()
    {
        int PP = PlayerPrefs.GetInt(constants.levelCompletedPlayerPrefs)+1;
        int x = 1;
        for (int i = 1; i <= variables.numberOfLevels; i++)
        {
            GameObject obj = Instantiate(this.obj,parent);
            Image buttonImage = obj.transform.GetChild(0).GetComponent<Image>();
            buttonImage.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
            int N = i;
            buttonImage.gameObject.GetComponent<Button>().onClick.AddListener(delegate { nextLevel(N); });
          

            if(PP < i)
            {
                img = _img;
                img1 = _img1;
                img2 = _img2;
                img3 = _img3;
                obj.transform.GetChild(0).GetComponent<Image>().sprite = _img;
                buttonImage.GetComponent<Button>().enabled = false;
            }

            if (i % 4 == 0)
            {
                buttonImage.sprite = img3;
                x = 0;
            }
            else if (x == 1)
            {
                //do nothing
            }
            else if (i % 2 != 0)
                buttonImage.sprite = img2;
            else if (i % 2 == 0)
                buttonImage.sprite = img1;
            else if (i % 1 == 0)
                buttonImage.sprite = img;
            x++;
            buttonImage.SetNativeSize();
        }
    }


    public void nextLevel(int N)
    {
       SoundManager.Instance.ButtonClickSound();
       variables.currentLevel = N-1;
       Application.LoadLevel(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Back();
    }
    public void Back()
    {
        print("Back");
        SoundManager.Instance.ButtonClickSound();
        Advertisements.Instance.ShowInterstitial();
        Destroy(this.gameObject);
    }



}
