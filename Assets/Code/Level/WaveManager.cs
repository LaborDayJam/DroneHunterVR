using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

	public Waypoint[] spawnPoints;

	public int MAX_DRONES = 15;
	public int droneCount = 0;

	float spawnInterval = 5.0f;
	int spawnsPerInterval = 2;

	float spawnTimer;

	void Start () {
		StartCoroutine (CR_SpawnRoutine ());
	}

	IEnumerator CR_SpawnRoutine()
	{
		spawnTimer = spawnInterval;
		while (true) {
			while(droneCount < MAX_DRONES)
			{
				spawnTimer -= Time.deltaTime;
				if(spawnTimer <= 0)
				{
					SpawnDrones();
					spawnTimer = spawnInterval;
				}
				yield return 0;
			}
		}
	}

	void SpawnDrones()
	{
		for(int i = 0; i < spawnsPerInterval; i++)
		{
			Waypoint spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
			Drone skirm = UnitFactory.instance.ConstructSkirmisher ();
			skirm.SetSpawnPoint (spawnPoint);
		}
	}
}
