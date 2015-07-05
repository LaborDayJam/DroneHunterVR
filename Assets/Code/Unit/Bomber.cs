using UnityEngine;
using System.Collections;

public class Bomber : Drone {

	public float attackRange = 20;
	// Use this for initialization
	void Start () {
		StartCoroutine ("CR_AttackRoutine");
	}

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
	}

	protected override void onDeath ()
	{
		base.onDeath ();
		StopCoroutine ("CR_AttackRoutine");
	}

}
