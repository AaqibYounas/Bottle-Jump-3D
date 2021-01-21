using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour {

    public Vector3 centerofMassVector;
    public bool awake;
    public Rigidbody rb;
    public float F;
	// Use this for initialization
	void OnEnable ()
    {
        //Invoke("dis", F);
	}
    private void dis()
    {
        GetComponent<CenterOfMass>().enabled = false;


    }
    // Update is called once per frame
    void Update ()
    {
        rb.centerOfMass = centerofMassVector;
        rb.WakeUp();
        awake = !rb.IsSleeping();
	}


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * centerofMassVector, 0.2f);
    }
}
