using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
	public GameObject healthExplosion;

	private Vector3 position;
	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(new Vector3(0, .5f, .5f));
		transform.position = new Vector3(position.x, transform.position.y, position.z);

		if(transform.position.y < 1.5)
			GetComponent<Rigidbody>().useGravity = false;
		else
			GetComponent<Rigidbody>().useGravity = true;
	}

	public void Destroy()
	{
		GameObject clone = Instantiate(healthExplosion, transform.position, Quaternion.identity)as GameObject;
	}
}
