using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
    private Vector3 Distance;
    public Transform Player;
    public Vector3 cameraTransform;
	// Use this for initialization
	void Start () 
    {
        this.Distance = this.transform.position - Player.transform.position;
        cameraTransform = this.GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
    void LateUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        this.transform.position = this.Distance + new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
    }

}
