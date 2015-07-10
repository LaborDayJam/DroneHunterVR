using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour 
{
	private RaycastHit 	hit;
	public Transform los;

	private float 		distance;

	// Use this for initialization
	void Start () 
	{
		Cursor.visible = false;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Physics.Raycast(new Ray(	los.position, 
		                           los.rotation * Vector3.forward * 15.0f), 
		                   			out hit))
		{
		
			if(hit.transform.tag == "drones")
				GetComponent<SpriteRenderer>().color = Color.red;
			else
				GetComponent<SpriteRenderer>().color = Color.white;
		}
	}
}