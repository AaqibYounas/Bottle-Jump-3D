using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class RateUs : MonoBehaviour
{
    [SerializeField]
    private GameObject BG;

    // Start is called before the first frame update
    void Start()
    {
		AnalyticsResult AR = Analytics.CustomEvent("RateUs : ");
		print (AR.ToString ());

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
		AnalyticsResult AR = Analytics.CustomEvent("RateUs : Yes");
		print (AR.ToString ());

        print("yes");
        PlayerPrefs.SetInt(constants.rateusUsedPlayerPrefs, 1);
        Destroy(gameObject);
        Application.LoadLevel("Level_" + (variables.currentLevel));
        Application.OpenURL("market://details?id=" + Application.productName);
    }

    public void noBTN()
    {
		AnalyticsResult AR = Analytics.CustomEvent("RateUs : No");
		print (AR.ToString ());

        print("no");
        int N = PlayerPrefs.GetInt(constants.rateusPlayerPrefs);
        PlayerPrefs.SetInt(constants.rateusPlayerPrefs, ++N);
        Destroy(gameObject);


        Application.LoadLevel("Level_" + (variables.currentLevel));
    }

}
