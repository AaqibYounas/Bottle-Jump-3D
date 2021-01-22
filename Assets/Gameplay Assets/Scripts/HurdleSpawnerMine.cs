using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleSpawnerMine : MonoBehaviour {


    public GameObject[] hurdles;
    public int numberOfHurdles = 10;
    public Transform parent;
    public Collider lastHurdle;
    public float randomDistance = 4;
	// Use this for initialization
	void Start ()
    {
        hurdleCreation();
    }
	



    void hurdleCreation()
    {
        
        for (int i = 0; i < numberOfHurdles ; i++)
        {
            GameObject hurdle = Instantiate(hurdles[Random.RandomRange(0, hurdles.Length)],parent);
            randomDistance = Random.RandomRange(1f,3f);
            hurdle.transform.position =  lastHurdle.gameObject.transform.position + new Vector3(0,0, lastHurdle.bounds.size.z);
            lastHurdle = hurdle.GetComponent<Collider>();   
        }
    }
}
