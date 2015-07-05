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
		GameObject skirmisher = (GameObject)GameObject.Instantiate(prefabSkirmisher);
		skirmisher.name = "Skirmisher";
		skirmisher.transform.parent = transform;
		return skirmisher.GetComponent<Drone>();
	}
	public Drone ConstructAvenger()
	{
		
		GameObject enemy = (GameObject)GameObject.Instantiate(prefabAvenger);
		enemy.name = "Avenger";
		return enemy.GetComponent<Drone>();
	}
}