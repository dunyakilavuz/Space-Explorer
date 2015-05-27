using UnityEngine;
using System.Collections;

public class RocketPhysics : MonoBehaviour 
{
	Vector3 myPosition;
	Rigidbody myRigidBody;
	int myThrottle;
	int maxThrottle = 100;
	float rotateSpeed = 1f;
	int altitude;
	int speed;
	float fuel = 100;
	int fuelForText;
	Vector3 earthPosition = new Vector3(0,0,0);
	float earthRadius = 5002f;
	public UnityEngine.UI.Text altitudeText;
	public UnityEngine.UI.Text throttleText;
	public UnityEngine.UI.Text speedText;
	public UnityEngine.UI.Text fuelText;

	public bool upperStageTank = false;
	public bool mainStageTank = true;
	public bool satelliteStageTank = false;
	public bool isScriptActive = false;
	public GameObject MainFlame;
	public GameObject UpperFlame;

	void isActive(bool enable)
	{
		isScriptActive = enable;
	}

	void Start () 
	{
		myRigidBody = gameObject.GetComponent<Rigidbody>();
		MainFlame.SetActive (false);
		UpperFlame.SetActive (false);
	}

	void FixedUpdate()
	{
		if (isScriptActive == true) 
		{
			ThrottleSpaceCraft ();
		}
	}

	void Update()
	{
		if (isScriptActive == true)
		{
			TextStuff ();
			RotateSpaceCraft ();
		}
	}

	void ThrottleSpaceCraft()
	{
		myRigidBody.AddForce(transform.up * myThrottle);



		if (mainStageTank == true) 
		{
			if (Input.GetKey (KeyCode.LeftShift) && myThrottle < maxThrottle) 
			{
				myThrottle = myThrottle + 1;
			}
			if (Input.GetKey (KeyCode.LeftControl) && myThrottle > 0)
			{
				myThrottle = myThrottle - 1;
			}
			if (Input.GetKey (KeyCode.Z)) 
			{
				myThrottle = maxThrottle;
			}
			if (Input.GetKey (KeyCode.X)) 
			{
				myThrottle = 0;
			}
			if (fuel <= 50) 
			{
				myThrottle = 0;
			}
			if(myThrottle > 0)
			{
				MainFlame.SetActive(true);
				UpperFlame.SetActive(false);
				fuel = fuel - myThrottle * 0.003f;
			}
			else
			{
				MainFlame.SetActive(false);
				UpperFlame.SetActive(false);
			}


		}
		else if (upperStageTank == true) 
		{
			if (Input.GetKey (KeyCode.LeftShift) && myThrottle < maxThrottle) 
			{
				myThrottle = myThrottle + 1;
			}
			if (Input.GetKey (KeyCode.LeftControl) && myThrottle > 0)
			{
				myThrottle = myThrottle - 1;
			}
			if (Input.GetKey (KeyCode.Z)) 
			{
				myThrottle = maxThrottle;
			}
			if (Input.GetKey (KeyCode.X)) 
			{
				myThrottle = 0;
			}
			if (fuel <= 0) 
			{
				myThrottle = 0;
			}
			if(myThrottle > 0)
			{
				MainFlame.SetActive(false);
				UpperFlame.SetActive(true);
				fuel = fuel - myThrottle * 0.00050f;
			}
			else
			{
				MainFlame.SetActive(false);
				UpperFlame.SetActive(false);
			}


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

	void TextStuff()
	{
		myPosition = transform.position;

		if (altitudeText != null) 
		{
			altitude = Mathf.CeilToInt((myPosition - earthPosition).magnitude - earthRadius);
			altitudeText.text = "Altitute: " + altitude + "m";;
		}
		if (throttleText != null) 
		{
			throttleText.text = "Throttle: %" + myThrottle;
		}
		if (speedText != null) 
		{
			speed = Mathf.CeilToInt(myRigidBody.velocity.magnitude);
			speedText.text = "Speed: " + speed + "m/s";
		}
		if (fuelText != null) 
		{
			fuelForText = Mathf.CeilToInt(fuel);

			if(fuel == 50 && mainStageTank == true)
			{
				fuelText.text = "Fuel: Deprived!";
			}
			else if(fuel == 0 && upperStageTank == true)
			{
				fuelText.text = "Fuel: Deprived!";
			}
			else
			{
				fuelText.text = "Fuel: %" + fuelForText;
			}

		}

	}
	void setStage()
	{ 
		mainStageTank = false;
		upperStageTank = true;
		fuel = 50;
		myThrottle = 30;
	}

}
