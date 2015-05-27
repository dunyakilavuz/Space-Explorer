using UnityEngine;
using System.Collections;

public class RocketStaging : MonoBehaviour 
{
	public bool liftOff_Stage = true;
	public bool upper_Stage = false;
	public bool seperation_Stage = false;
	public bool satelliteDeploy_Stage = false;

	public GameObject Rocket;
	public GameObject SatelliteStage;
	public GameObject UpperStage;
	public GameObject MainStage;
	public GameObject Fairing;
	public GameObject Panels;
	bool sendFalse = false;
	bool sendTrue = true;

	void Start () 
	{
		MainStage.SendMessage("isActive",sendTrue);
		UpperStage.SendMessage("isActive",sendFalse);
		SatelliteStage.SendMessage ("isActive", sendFalse);
	}

	void Update ()
	{
		if (liftOff_Stage == true)
		{
			if(Input.GetKeyUp(KeyCode.Space))
			{
				liftOff_Stage = false;
				upper_Stage = true;
				seperation_Stage = true;
			}
		}

		if (upper_Stage == true) 
		{
			if(seperation_Stage == true)
			{
				seperation_Stage = false;
				UpperStage.transform.SetParent(Rocket.transform);
				MainStage.SendMessage("isActive",sendFalse);
				SatelliteStage.SendMessage ("isActive", sendFalse);
				UpperStage.SendMessage("isActive",sendTrue);
				UpperStage.SendMessage("setStage");
			}
			if(Input.GetKeyDown(KeyCode.Space))
			{
				upper_Stage = false;
				satelliteDeploy_Stage = true;
				seperation_Stage = true;
			}

		}

		if (satelliteDeploy_Stage == true) 
		{
			if(seperation_Stage == true)
			{
				seperation_Stage = false;
				SatelliteStage.transform.SetParent(Rocket.transform);
				MainStage.SendMessage("isActive",sendFalse);
				UpperStage.SendMessage("isActive",sendFalse);
				SatelliteStage.SendMessage ("isActive", sendTrue);
			}
			Destroy(Fairing);
			if(Input.GetKeyDown(KeyCode.Space))
			{
				Panels.SetActive(true);
			}

		}
	}
}
