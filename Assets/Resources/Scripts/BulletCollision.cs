using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour 
{


	void Start()
	{
	
	}
	void Update()
	{

	}


	void OnCollisionEnter(Collision Other)
	{
		switch(Other.transform.tag)
		{
			case "drones":
			{
				Other.gameObject.GetComponent<Unit>().health -= 2;
				
			}break;
			case "Missile":
			{
				Destroy(Other.gameObject);
			}break;
		}


	}
}
