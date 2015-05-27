using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{

	public Transform target;
	public Camera myCamera;
	Quaternion rotation;
	float x = 0.0f;
	float y = 0.0f;
	float maxZoom = 30;
	float minZoom = 60;

	void Start () 
	{
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if (Input.GetMouseButton (1)) 
		{
			x = x + Input.GetAxis ("Mouse X");
			y = y - Input.GetAxis("Mouse Y");
			rotation = Quaternion.Euler (y, x, 0);
			
			transform.rotation = rotation;
		}

	}

}
