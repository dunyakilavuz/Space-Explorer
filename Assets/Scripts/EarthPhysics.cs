using UnityEngine;
using System.Collections;

public class EarthPhysics : MonoBehaviour {

	Rigidbody myRidigBody;
	float rotateSpeed;
	Vector3 targetPosition;
	float earthMass = Mathf.Pow(15.2f,14);
	float GravityConstant = 6.674f * Mathf.Pow (10, -11);
	Vector3 earthPosition;
	Vector3 gravityVector;
	public float gravity;
	public Rigidbody affectedObject;

	void Start () 
	{
		myRidigBody = gameObject.GetComponent<Rigidbody>();
		myRidigBody.mass = earthMass;
		//rotateSpeed = 0.005f;

	}

	void Update () 
	{

	}

	void FixedUpdate()
	{
		EarthGravity (affectedObject);
	}

	void EarthGravity(Rigidbody targetRigidBody)
	{
		targetPosition = targetRigidBody.gameObject.transform.position;
		gravityVector = earthPosition - targetPosition;
		gravity = GravityConstant * targetRigidBody.mass * earthMass / Mathf.Pow(gravityVector.magnitude,2);
		targetRigidBody.AddForce (gravityVector.normalized * gravity);
	}
}
