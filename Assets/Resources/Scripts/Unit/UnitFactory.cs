using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum UnitType {Skirmisher, Avenger, Bomber }
public class UnitFactory : MonoBehaviour {
	
	static UnitFactory _instance;
	
	public static UnitFactory instance
	{
		get { return _instance; }
	}

	void Awake()
	{
		if (instance == null)
		{
			_instance = this;
		}	
		else
			Destroy(gameObject);
	}

	public GameObject prefabSkirmisher, prefabAvenger, prefabBomber;
	
	List<Unit> lUnits;
	
	public Drone ConstructSkirmisher()
	{
		GameObject enemy = (GameObject)GameObject.Instantiate(prefabSkirmisher);
		enemy.name = "Skirmisher";
		enemy.transform.LookAt(GameObject.FindGameObjectWithTag("target").GetComponent<Transform>().position);
		enemy.transform.parent = transform;
		return enemy.GetComponent<Drone>();
	}
	public Drone ConstructAvenger()
	{
		
		GameObject enemy = (GameObject)GameObject.Instantiate(prefabAvenger);
		enemy.name = "Avenger";
		return enemy.GetComponent<Drone>();
	}

	
	public Drone ConstructBomber()
	{
		GameObject enemy = (GameObject)GameObject.Instantiate(prefabBomber);
		enemy.name = "Bomber";
		enemy.transform.LookAt(GameObject.FindGameObjectWithTag("target").GetComponent<Transform>().position);
		enemy.transform.parent = transform;
		return enemy.GetComponent<Drone>();
	}
}