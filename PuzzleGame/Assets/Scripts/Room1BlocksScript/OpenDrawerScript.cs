using UnityEngine;
using System.Collections;

public class OpenDrawerScript : MonoBehaviour {

	Vector3 positionToMoveTowards;
	float drawerMovementSpeed = .6F;

	// Use this for initialization
	void Start ()
	{
		var distanceToMove = (float)((transform.GetComponentInChildren<Renderer>().bounds.extents.z * 2) * .75);
		positionToMoveTowards = transform.position + new Vector3(0, 0, distanceToMove);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.MoveTowards(transform.position, positionToMoveTowards, drawerMovementSpeed * Time.deltaTime);
	}
}
