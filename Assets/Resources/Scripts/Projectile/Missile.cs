using UnityEngine;
using System.Collections;

public class Missile : Unit {
	public GameObject missileExplosion;
	Transform target;
	public float damage = 100;
	public float distanceThreshold = 1;

	// Update is called once per frame
	IEnumerator CR_HomingMovementRoutine(){
		//TODO optimize and not use distance
		while (Mathf.Abs( Vector3.Distance(transform.position, target.position)) > distanceThreshold) {
			Vector3 dir = (target.position - transform.position).normalized;
			transform.position += dir * speed * Time.deltaTime;
			yield return 0;
		}
		Unit targetUnit = target.GetComponent<Unit> ();
		if (targetUnit != null) {
			Damage (targetUnit, damage);
			GameObject clone = Instantiate(missileExplosion, transform.position, transform.rotation)as GameObject;
			Destroy(gameObject);
		}
	}

	public void SetTarget(Transform tf)
	{
		target = tf;
		transform.LookAt(target.localPosition);
		StartCoroutine ("CR_HomingMovementRoutine");
	}

}
