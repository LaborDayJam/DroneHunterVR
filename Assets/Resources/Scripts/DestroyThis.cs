using UnityEngine;
using System.Collections;

public class DestroyThis : MonoBehaviour 
{
	public float time;
	void Start () 
	{
		DestroyObject(this.gameObject, time);
	}

}
