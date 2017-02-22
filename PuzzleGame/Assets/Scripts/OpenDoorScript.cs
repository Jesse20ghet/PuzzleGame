using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {

	private float rotationSpeed = .5F;

	float doorOpenAngle = 135F;
	Vector3 openRot;
	Vector3 defaultRot;

	// Use this for initialization
	void Start ()
	{
		defaultRot = transform.eulerAngles;
		openRot = new Vector3(defaultRot.x, defaultRot.y + doorOpenAngle, defaultRot.z);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * rotationSpeed);

		if (transform.eulerAngles.y > doorOpenAngle - 10)
			Destroy(this);
	}
}
