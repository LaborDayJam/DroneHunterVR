﻿using UnityEngine;
using System.Collections;

public class Drone : Unit {

	float damage;
	float rof;

	Waypoint nextWayPoint;

	IEnumerator FollowWaypoints() {
		Vector3 nextWaypointPosition = nextWayPoint.transform.position;
		Vector3 dir;
		while (nextWayPoint != null) {
			//Move until I am near the next waypoint
			while (Mathf.Abs( Vector3.Distance(transform.position, nextWaypointPosition)) > .1f) {
				dir = (nextWaypointPosition - transform.position).normalized;
				transform.position += dir * speed * Time.deltaTime;
				yield return 0;
			}
			//Update to the next Waypoint
			nextWayPoint = nextWayPoint.nextWaypoint;
			nextWaypointPosition = nextWayPoint.transform.position;
			yield return 0;
		}
	}

	public void SetSpawnPoint(Waypoint spawnPoint)
	{
		transform.position = spawnPoint.transform.position;
		nextWayPoint = spawnPoint.nextWaypoint;
		StartCoroutine (FollowWaypoints());
	}
}