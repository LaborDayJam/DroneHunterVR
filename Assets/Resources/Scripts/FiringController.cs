using UnityEngine;
using System.Collections;

public class FiringController : MonoBehaviour 
{
	
	public GameObject centerEye;
	public GameObject firingStart;
	public GameObject bullet;
	private InputController input;
	private RaycastHit hit;
	private float distance;
	private float firingTimer = .2f; 
	private float fireTime = 0;
	private bool  isSight;


	// Use this for initialization
	void Start () 
	{
		input = gameObject.GetComponent<InputController>();
	}

	// Update is called once per frame
	void Update () 
	{

		if(input.is1Touch)
		{
			if(fireTime > firingTimer)
			{
				GameObject clone = Instantiate(bullet, firingStart.transform.position, firingStart.transform.rotation)as GameObject;
				fireTime = 0;
				clone.GetComponent<Rigidbody>().velocity = firingStart.transform.TransformDirection(new Vector3(0, 0,80));
			}
		}

		if(fireTime < firingTimer)
			fireTime += Time.deltaTime;

		 
	}
}
