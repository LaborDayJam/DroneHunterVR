using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour 
{

	public bool is1Touch;


	private bool isAndroid;


	// Use this for initialization
	void Start () 
	{
		isAndroid =false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isAndroid)
			HandleTouchPad();
		else 
			HandleMouseButtons();
    }

	void HandleTouchPad()
	{
		if(Input.touchCount > 0 && Input.touchCount < 1 )
			is1Touch = true;
		else 
			is1Touch = false;



	}

	void HandleMouseButtons()
	{
		if(Input.GetMouseButton(0))
			is1Touch = true;
		else 
			is1Touch = false;

	}
}
