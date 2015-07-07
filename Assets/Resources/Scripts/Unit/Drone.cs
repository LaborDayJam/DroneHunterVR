using UnityEngine;
using System.Collections;

public class Drone : Unit {

	public static Player player;
	public float damage = 10;
	public float rof = 1;

	private bool bomber;
	protected Waypoint nextWayPoint;
	protected float distanceThreshold = .1f;

	protected virtual IEnumerator FollowWaypoints() {
		Vector3 nextWaypointPosition = nextWayPoint.transform.position;
		Vector3 dir; 
		Vector3 target = GameObject.FindGameObjectWithTag("target").transform.position;
		Waypoint oldWaypoint;
		while (nextWayPoint != null) {
			//Move until I am near the next waypoint
			//TODO optimize and not use Vector3.Distance
			while (Mathf.Abs( Vector3.Distance(transform.position, nextWaypointPosition)) > distanceThreshold) 
			{
				dir = (nextWaypointPosition - transform.position).normalized;
				transform.position += dir * speed * Time.deltaTime;

				if(this.gameObject.transform.name == "Bomber")
				{
					if(!bomber)
					{
						dir = (target - transform.position).normalized;
						dir.y = 0;
						transform.forward = dir;
						bomber = true;
					}
				}
				else
				{
					dir = (target - transform.position).normalized;
					dir.y = 0;
					transform.forward = dir;
				}
				yield return 0;
			}
			oldWaypoint = nextWayPoint;

			//Update to the next Waypoint
			while(nextWayPoint == oldWaypoint)
				nextWayPoint = nextWayPoint.nextWaypoint;

			if(nextWayPoint)
				nextWaypointPosition = nextWayPoint.transform.position;
			else
				break;
			yield return 0;
		}
	}

	public void SetSpawnPoint(Waypoint spawnPoint)
	{
		transform.position = spawnPoint.transform.position;
		nextWayPoint = spawnPoint.nextWaypoint;
		StartCoroutine ("FollowWaypoints");
	}

	protected override void onDeath()
	{
		base.onDeath();
		StopCoroutine ("FollowWaypoints");	
	}
}
