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
	private float firingTimer = 1.5f; 
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
				GameObject clone = Instantiate(bullet, firingStart.transform.position, transform.rotation)as GameObject;
				fireTime = 0;
			}
		}

		if(fireTime < firingTimer)
			fireTime += Time.deltaTime;
	}
}
