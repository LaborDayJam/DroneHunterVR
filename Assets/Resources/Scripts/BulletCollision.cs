using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour 
{
	public GameObject droneExplosion;
	public GameObject otherExplosion;

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
			switch(Other.transform.tag)
			{
				case "drones":
				{
					Other.gameObject.GetComponent<Unit>().health -= 1;
					GameObject clone = Instantiate(droneExplosion, transform.position, transform.rotation) as GameObject;
					clone.transform.SetParent(Other.transform);
					Destroy(this.gameObject);
				}break;
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
			}
		}
	}
}
