using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForce : MonoBehaviour {

	public float force;
	public Vector3 forceAngle;
	public float delayTime;
	public Rigidbody[] objects;
    public ITweenMagic[] IT;
    // Use this for initialization

    public void forceTrigger () 
	{
        if(IT.Length > 0)
        {
            foreach (ITweenMagic O in IT)
            {
                O.enabled = true;
            }
        }
        else
   		    StartCoroutine (applyForce());
	}


	IEnumerator applyForce()
	{
		yield return new WaitForSeconds (delayTime);
		foreach (Rigidbody O in objects) 
		{
			O.AddForce (force * forceAngle, ForceMode.Impulse);
		}
	}



}
