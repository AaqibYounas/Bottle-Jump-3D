using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
    public Vector3 Distance;
    public Transform Player;
    public Vector3 cameraTransform;
    private float cameraY;
	// Use this for initialization
	void Start () 
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //this.Distance = this.transform.position - Player.transform.position;
        cameraTransform = this.GetComponent<Transform>().position;
        //this.transform.position = this.Distance + new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        cameraY = transform.position.y;
    }
	
	// Update is called once per frame
    void FixedUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        this.transform.position = this.Distance + new Vector3(Player.transform.position.x, cameraY, Player.transform.position.z);
    }

}
