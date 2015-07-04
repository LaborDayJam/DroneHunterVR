using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public float baseHealth = 100;

	public float speed;

	private float _health;
	public float health {
		get { return _health; }
		set { 
			_health = value; 
			if(_health <= 0)
				onDeath();
		}
	}

	// Use this for initialization
	void Start () {
		health = baseHealth;
	}


	public void Damage(Unit other, float damage)
	{
		other.health -= damage;
	}

	void onDeath()
	{
		
	}

}
