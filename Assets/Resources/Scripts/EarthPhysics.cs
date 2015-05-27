using UnityEngine;
using System.Collections;

public class EarthPhysics : MonoBehaviour {

	Rigidbody myRidigBody;
	float rotateSpeed;
	Vector3 targetPosition;
	float earthMass = Mathf.Pow(15,16);
	float GravityConstant = 6.674f * Mathf.Pow (10, -11);
	Vector3 earthPosition;
	Vector3 gravityVector;
	public float gravity;
	public Rigidbody UpperStage;
	public Rigidbody MainStage;

	void Start () 
	{
		myRidigBody = gameObject.GetComponent<Rigidbody>();
		myRidigBody.mass = earthMass;

	}

	void Update () 
	{

	}

	void FixedUpdate()
	{
		if (UpperStage != null) 
		{
			EarthGravity (UpperStage);
		}
		if (MainStage != null)
		{
			EarthGravity (MainStage);
		}
	}

	void EarthGravity(Rigidbody targetRigidBody)
	{
		targetPosition = targetRigidBody.gameObject.transform.position;
		gravityVector = earthPosition - targetPosition;
		gravity = GravityConstant * targetRigidBody.mass * earthMass / Mathf.Pow(gravityVector.magnitude,2);
		targetRigidBody.AddForce (gravityVector.normalized * gravity);
	}
}
