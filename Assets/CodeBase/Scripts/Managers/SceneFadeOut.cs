using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFadeOut : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float destoryTime;
    void Start()
    {

        transform.GetChild(0).gameObject.SetActive(true);
       Destroy(this.gameObject,destoryTime);

      //StartCoroutine(destory());
    }


    IEnumerator destory()
    {
        yield return new WaitForSeconds(.45f);
        print("apple");
        this.gameObject.SetActive(false);
    }



}
