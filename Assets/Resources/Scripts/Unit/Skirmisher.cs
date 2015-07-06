﻿using UnityEngine;
using System.Collections;

public class Skirmisher : Drone 
{
	public GameObject droneExplosion;
	// Use this for initialization
	void Start () {
		StartCoroutine ("CR_AttackRoutine");
	}

	IEnumerator CR_AttackRoutine()
	{
		//Only attack when on edge
		while (nextWayPoint != null && !nextWayPoint.isEdge) {
			yield return 0;
		}

		while (true) {
			ReadyAttack();
			yield return new WaitForSeconds(rof);
			Attack();
			yield return 0;
		}
	}

	protected override void onDeath()
	{
		base.onDeath();
		GameObject clone = Instantiate(droneExplosion, transform.position, transform.rotation) as GameObject;
		GetComponent<DestroyBullet>().enabled = true;
		GetComponent<Rigidbody>().isKinematic = false;
		StopCoroutine ("CR_AttackRoutine");
	}

	void ReadyAttack()
	{
		//Show red dot indicating it is preparing to attack
	}

	void Attack()
	{
		//attack the player
	}
}