﻿using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour 
{
	public float time;
	void Start () 
	{
		DestroyObject(this.gameObject, time);
	}

}
