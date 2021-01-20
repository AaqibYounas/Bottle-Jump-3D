using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUs : MonoBehaviour
{
    [SerializeField]
    private GameObject BG;

    // Start is called before the first frame update
    void Start()
    {
        /*
        if (PlayerPrefs.GetInt(constants.rateusUsedPlayerPrefs) == 0)
        {
            int N = PlayerPrefs.GetInt(constants.rateusPlayerPrefs);

            if (N % 3 == 0)
            {
                Instantiate(Resources.Load(constants.rateUS));
            }
            else
            {
                PlayerPrefs.SetInt(constants.rateusPlayerPrefs, ++N);
            }
        }
        */
    }

    public void yesBTN()
    {
        print("yes");
        PlayerPrefs.SetInt(constants.rateusUsedPlayerPrefs, 1);
        Destroy(gameObject);
        Application.LoadLevel(1);
        Application.OpenURL("market://details?id=" + Application.productName);
    }

    public void noBTN()
    {
        print("no");
        int N = PlayerPrefs.GetInt(constants.rateusPlayerPrefs);
        PlayerPrefs.SetInt(constants.rateusPlayerPrefs, ++N);
        Destroy(gameObject);


        Application.LoadLevel(1);
    }

}
