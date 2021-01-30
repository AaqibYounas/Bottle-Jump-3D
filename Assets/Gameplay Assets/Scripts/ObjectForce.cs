using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForce : MonoBehaviour {

	public float force;
	public Vector3 forceAngle;
	public float delayTime;
	public Rigidbody[] objects;
	// Use this for initialization
	public void forceTrigger () 
	{
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
