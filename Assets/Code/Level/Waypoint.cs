using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	public Waypoint[] nextWayPoints;
	public Waypoint nextWaypoint { 
		get { 
			if(nextWayPoints == null || nextWayPoints.Length == 0)
				return null;
			return nextWayPoints[Random.Range(0, nextWayPoints.Length)]; 
		}
	}

}
