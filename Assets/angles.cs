using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public float xAngle;
public float xAngle2;
public float xAngle3;

	// Update is called once per frame
	void Update () {
		        xAngle = transform.eulerAngles.x;


        xAngle2= UnwrapAngle(transform.localRotation.x) ;

	}

	public float UnwrapAngle(float angle)
        {
            if(angle >=0)
                return angle;
 
            angle = -angle%360;
 
            return 360-angle;
        }
}
