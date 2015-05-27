using UnityEngine;
using System.Collections;

public class RocketStaging : MonoBehaviour 
{
	bool liftOff_Stage = true;
	bool upper_Stage = false;
	bool seperation_Stage = false;
	bool satelliteDeploy_Stage = false;

	public GameObject Rocket;
	public GameObject UpperStage;
	public GameObject MainStage;
	bool sendFalse = false;
	bool sendTrue = true;

	void Start () 
	{
		MainStage.SendMessage("isActive",sendTrue);
		UpperStage.SendMessage("isActive",sendFalse);
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
			if(Input.GetKeyUp(KeyCode.Space))
			{
				upper_Stage = false;
				satelliteDeploy_Stage = true;
			}

			if(seperation_Stage == true)
			{
				seperation_Stage = false;
				UpperStage.transform.SetParent(Rocket.transform);
				MainStage.SendMessage("isActive",sendFalse);
				UpperStage.SendMessage("isActive",sendTrue);
				UpperStage.SendMessage("setStage");
			}


		}

		if (satelliteDeploy_Stage == true) 
		{

		}
	}
}
