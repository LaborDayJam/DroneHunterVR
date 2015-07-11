using UnityEngine;
using System.Collections;

public class Skirmisher : Drone 
{
	public ParticleSystem firingLight;
	public GameObject bullet;

	private float fireTimer = 5;
	private float fireTime = 0;
	private float attackRange = 3;


	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("CR_AttackRoutine");
		firingLight.Stop();
	}

	IEnumerator CR_AttackRoutine()
	{
		//Only attack when on edge
		while (nextWayPoint != null && !nextWayPoint.isEdge) {
			yield return 0;
		}

		while (Mathf.Abs( Vector3.Distance(player.transform.position,transform.position)) >  attackRange) {
			ReadyAttack();
			yield return new WaitForSeconds(firingLight.duration  * .75f);
			Attack();
			yield return new WaitForSeconds(fireTimer); 
			yield return 0;
		}
	}

	protected override void onDeath()
	{
		base.onDeath();
		GetComponent<DestroyThis>().enabled = true;
		GetComponent<Rigidbody>().isKinematic = false;
		StopCoroutine ("CR_AttackRoutine");
	}

	void ReadyAttack()
	{
		firingLight.Play();
	}

	void Attack()
	{
		//attack the player
		GameObject clone  = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(0,0,80);
		firingLight.Stop();
	}
}
