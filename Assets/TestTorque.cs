using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTorque : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().AddTorque(Vector3.forward * 9999f,ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
