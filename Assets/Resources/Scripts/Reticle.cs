using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour 
{
	private RaycastHit 	hit;
	private Transform 	camera;
	private Camera 		theCam;

	private float 		distance;

	// Use this for initialization
	void Start () 
	{

		camera = GameObject.Find("RightEyeAnchor").GetComponent<Transform>();	
		theCam = camera.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Physics.Raycast(new Ray(	camera.transform.position, 
		                           	camera.transform.rotation * Vector3.forward * 2.0f), 
		                   			out hit))
		{
			distance = hit.distance * .95f;

			if(distance > 10)
			     distance = 10;
		}
		else
		{
			distance = 10;
		}
		Vector3 aposition = new Vector3(camera.transform.position.x, camera.transform.position.y - 1.5f, camera.transform.position.z);
		transform.position = aposition + camera.transform.rotation * Vector3.forward * (distance );
		transform.LookAt(camera.transform.position);
		transform.Rotate(0,180.0f,0);
	}







































}
