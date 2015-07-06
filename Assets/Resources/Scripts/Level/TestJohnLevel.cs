using UnityEngine;
using System.Collections;

public class TestJohnLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Waypoint spawnPoint = GameObject.Find ("spawn0").GetComponent<Waypoint>();
		Debug.Log (spawnPoint);
		Drone skirm = UnitFactory.instance.ConstructSkirmisher ();
		skirm.SetSpawnPoint (spawnPoint);
	}

}
