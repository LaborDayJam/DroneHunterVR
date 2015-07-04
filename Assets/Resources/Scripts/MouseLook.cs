using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour 
{
	float rotationSpeed = 60;
	float bankingSpeed = 4;
	
	private float mouseX = 0.0f;
	private float mouseY = 0.0f;
	
	void Update () {
		
		float bankingAngle = 0.0f;
		
		// Normalized mouse input
		mouseX = ((Input.mousePosition.x - Screen.width / 2.0f) / (Screen.width / 2.0f));
		mouseY = ((Input.mousePosition.y - Screen.height / 2.0f) / (Screen.height / 2.0f));
		
		// Rotate camera
		transform.Rotate(-Vector3.right * (mouseY * rotationSpeed) * Time.deltaTime);
		transform.Rotate(Vector3.up * (mouseX * rotationSpeed) * Time.deltaTime);
		
		// Calculate banking angle
		bankingAngle = Mathf.LerpAngle(transform.eulerAngles.z,  -mouseX * 15, Time.deltaTime * bankingSpeed );
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, bankingAngle);
		
	}
}