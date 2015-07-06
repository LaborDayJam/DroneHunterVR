using UnityEngine;
using System.Collections;

public class Bomber : Drone {

	public float attackRange = 20;
	public GameObject prefabMissile;

	void Start () {
		StartCoroutine ("CR_AttackRoutine");
		distanceThreshold = 2;
	}

	//Attack once
	IEnumerator CR_AttackRoutine()
	{
		while (true) {
			while (Mathf.Abs( Vector3.Distance(transform.position, player.transform.position)) > attackRange) {
				yield return 0;
			}
			Attack ();
			break;
		}
	}

	void Attack()
	{
		//Launch missile
		GameObject missile = (GameObject)Instantiate (prefabMissile, transform.position - transform.up, transform.rotation);
		missile.GetComponent<Missile> ().SetTarget (player.transform);
	}

	protected override void onDeath ()
	{
		base.onDeath ();
		GetComponent<DestroyThis>().enabled = true;
		GetComponent<Rigidbody>().isKinematic = false;
		StopCoroutine ("CR_AttackRoutine");
	}
}
