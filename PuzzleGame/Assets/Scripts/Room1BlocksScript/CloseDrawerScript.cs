using UnityEngine;
using System.Collections;

public class CloseDrawerScript : MonoBehaviour {

	Vector3 positionToMoveTowards;
	float drawerMovementSpeed = .6F;


	// Use this for initialization
	void Start()
	{
		positionToMoveTowards = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, positionToMoveTowards, drawerMovementSpeed * Time.deltaTime);
	}
}
