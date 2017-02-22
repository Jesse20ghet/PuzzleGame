using UnityEngine;
using System.Collections;

public class TrashCanTiltOverScript : MonoBehaviour {

	private Quaternion targetRotation;

	// Use this for initialization
	void Start()
	{
		targetRotation = transform.rotation;
		targetRotation *= Quaternion.AngleAxis(90, Vector3.forward);
	}

	// Update is called once per frame
	void Update()
	{
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 5 * Time.deltaTime);

		if (transform.rotation == targetRotation)
			Destroy(this);
	}
}
