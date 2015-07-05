using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour 
{
	private Transform sightLine;

	void Start()
	{
		sightLine = GameObject.Find("SightLinePosition").GetComponent<Transform>();
	}
	void Update()
	{
		//transform.Translate(transform.forward * 2f * Time.deltaTime); 
	}
}
