using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

	public Waypoint[] skirmisherSpawnPoints;
	public Waypoint[] bomberSpawnPoints;

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
					if(Random.Range(0, 100) > 50)
						SpawnDrones();
					else
						SpawnBomber();
					spawnTimer = spawnInterval;
				}
				yield return 0;
			}
			yield return 0;
		}
	}

	void SpawnDrones()
	{
		for(int i = 0; i < spawnsPerInterval; i++)
		{
			Waypoint spawnPoint = skirmisherSpawnPoints[Random.Range(0, skirmisherSpawnPoints.Length)];
			Drone skirm = UnitFactory.instance.ConstructSkirmisher ();
			skirm.SetSpawnPoint (spawnPoint);
			droneCount++;
		}
	}

	void SpawnBomber()
	{
		Waypoint spawnPoint = bomberSpawnPoints[Random.Range(0, bomberSpawnPoints.Length)];
		Drone bomber = UnitFactory.instance.ConstructBomber();
		bomber.SetSpawnPoint (spawnPoint);
		droneCount++;
	}

	void onDroneDestroyed()
	{
		droneCount--;
	}
}
