using UnityEngine;
using System.Collections;

public class RocketPhysics : MonoBehaviour 
{
	Vector3 myPosition;
	Rigidbody myRigidBody;
	float myThrottle;
	float maxThrottle = 310f;
	float rotateSpeed = 1f;
	int altitude;
	int speed;
	Vector3 earthPosition = new Vector3(0,0,0);
	float earthRadius = 502f;
	public UnityEngine.UI.Text altitudeText;
	public UnityEngine.UI.Text throttleText;
	public UnityEngine.UI.Text speedText;

	void Start () 
	{
		myRigidBody = gameObject.GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		ThrottleSpaceCraft ();
	}

	void Update()
	{
		myAltitude_Throttle_Speed ();
		RotateSpaceCraft ();
	}

	void ThrottleSpaceCraft()
	{
		myRigidBody.AddForce(transform.up * myThrottle);

		if(Input.GetKey(KeyCode.LeftShift) && myThrottle < maxThrottle)
		{
			myThrottle = myThrottle + 0.5f;
		}
		if (Input.GetKey(KeyCode.LeftControl) && myThrottle > 0) 
		{
			myThrottle = myThrottle - 0.5f;
		}
		if(Input.GetKey(KeyCode.Z))
		{
			myThrottle = maxThrottle;
		}
		if (Input.GetKey (KeyCode.X)) 
		{
			myThrottle = 0f;
		}
		  
	}
	void RotateSpaceCraft()
	{

		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Rotate(-rotateSpeed,0,0);
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Rotate(0,0,rotateSpeed);
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			transform.Rotate(rotateSpeed,0,0);
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Rotate(0,0,-rotateSpeed);
		}
	}

	void myAltitude_Throttle_Speed()
	{
		myPosition = transform.position;
		altitude = Mathf.CeilToInt((myPosition - earthPosition).magnitude - earthRadius);
		speed = Mathf.CeilToInt(myRigidBody.velocity.magnitude);

		altitudeText.text = "Altitute: " + altitude + "m";;

		throttleText.text = "Throttle: " + myThrottle;

		speedText.text = "Speed: " + speed + "m/s";





	}

}
