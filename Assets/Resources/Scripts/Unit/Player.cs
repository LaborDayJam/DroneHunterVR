using UnityEngine;
using System.Collections;

public class Player : Unit {

	void Awake()
	{
		Drone.player = this;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
