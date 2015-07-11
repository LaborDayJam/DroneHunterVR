using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour 
{
	public GameObject droneExplosion;
	public GameObject otherExplosion;
	public bool 	  playerBullet;
	void Start()
	{
	
	}
	void Update()
	{

	}


	void OnCollisionEnter(Collision Other)
	{
		if(Other.transform.tag != null)
	    {
		    if(playerBullet)
			{
				switch(Other.transform.tag)
				{
					case "drones":
					{
						if(Other.gameObject.name == "Skirmisher")
							Other.gameObject.GetComponent<Skirmisher>().health -=1;
						else if(Other.gameObject.name == "Bomber")
							Other.gameObject.GetComponent<Bomber>().health -=1;
		
						
						GameObject clone = Instantiate(droneExplosion, transform.position, transform.rotation) as GameObject;
						clone.transform.SetParent(Other.transform);
						Destroy(this.gameObject);
					}break;
				}
			}
			else
			{
				switch(Other.transform.tag)
				{
				case "Player":
				{
					GameObject clone = Instantiate(droneExplosion, transform.position, transform.rotation) as GameObject;
					clone.transform.SetParent(Other.transform);
					Destroy(this.gameObject);
				}break;
				}
			}
			switch(Other.transform.tag)
			{
				case "missile":
				{
					GameObject clone = Instantiate(droneExplosion, transform.position, transform.rotation) as GameObject;
					Destroy(Other.gameObject);
					Destroy(this.gameObject);
				}break;
				case "others":
				{
					GameObject clone = Instantiate(otherExplosion, transform.position, transform.rotation) as GameObject;
					Destroy(this.gameObject);
				}break;

				case "power":
				{
					Other.gameObject.GetComponent<Health>().Destroy();
					Destroy(Other.gameObject);
					Destroy(this.gameObject);
				}break;
			}
		}
	}
}
