using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour 
{
	
	void Start () 
	{
		DestroyObject(this.gameObject, 3f);
	}

}
