using UnityEngine;
using System.Collections;

public class JohnLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Waypoint spawnPoint = GameObject.Find ("spawn0").GetComponent<Waypoint>();
		Drone skirm = UnitFactory.instance.ConstructSkirmisher ();
		skirm.SetSpawnPoint (spawnPoint);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
