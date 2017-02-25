using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveBlockScript : MonoBehaviour {

	public List<GameObject> createdTrailCubes = new List<GameObject>();
	public GameObject controller;
	public static int CurrentCubes = 1;

	float movementLength;
	float movementCheckLength;
	float movementSpeed = 2f;
	Vector3 vectorToMoveTowards;
	bool isMoving;
	Vector3 startingPosition;
	GameObject trailCube;

	bool spawnCube;
	Vector3 oldPosition;

	// Use this for initialization
	void Start () 
	{
		vectorToMoveTowards = transform.position;
		movementLength = transform.GetComponent<BoxCollider> ().bounds.extents.x * 2;
		movementCheckLength = movementLength * 1.4F;
		isMoving = false;
		startingPosition = transform.position;

		if(transform.name.Contains("Red"))
			trailCube = (GameObject)Resources.Load("RedTrailCube");

		if(transform.name.Contains("Green"))
			trailCube = (GameObject)Resources.Load("GreenTrailCube");

		if (transform.name.Contains("Blue"))
			trailCube = (GameObject)Resources.Load("BlueTrailCube");

		if (transform.name.Contains("Cyan"))
			trailCube = (GameObject)Resources.Load("CyanTrailCube");

		if (transform.name.Contains("Orange"))
			trailCube = (GameObject)Resources.Load("OrangeTrailCube");

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (vectorToMoveTowards == transform.position) 
		{
			if(spawnCube)
			{
				var x = (GameObject)GameObject.Instantiate(trailCube, oldPosition, transform.rotation);
				x.name = transform.name + "TrailBox";
				x.transform.parent = transform.parent.transform;
				
				createdTrailCubes.Add(x);
				controller.SendMessage("UpdateUI", 1);
				spawnCube = false;
			}

			isMoving = false;
		}
		else 
		{
			transform.position = Vector3.MoveTowards(transform.position, vectorToMoveTowards, movementSpeed * Time.deltaTime);
			isMoving = true;
		}
	}

	void Activate(GameObject player)
	{
		if (isMoving)
			return;

		RaycastHit rayCastHit;
		Vector3 movementVector = new Vector3(0, 1, 0);
		var cubePosition = transform.position;

		var xDiff = player.transform.position.x - cubePosition.x;
		var zDiff = player.transform.position.z - cubePosition.z;

		var moveXDirection = Mathf.Abs(xDiff) > Mathf.Abs(zDiff);
		if (moveXDirection)
		{
			if (player.transform.position.x > cubePosition.x)
				movementVector = new Vector3(-movementLength, 0, 0);
			if (player.transform.position.x <= cubePosition.x)
				movementVector = new Vector3(movementLength, 0, 0);
		}
		else
		{
			if (player.transform.position.z > cubePosition.z)
				movementVector = new Vector3(0, 0, -movementLength);
			if (player.transform.position.z <= cubePosition.z)
				movementVector = new Vector3(0, 0, movementLength);
		}

		Physics.Raycast(transform.position, movementVector, out rayCastHit, movementCheckLength, 1111111111);
		if (rayCastHit.transform == null)
		{
			oldPosition = transform.position;
			spawnCube = true;
			vectorToMoveTowards = transform.position + movementVector;
		}
		else if (rayCastHit.transform.gameObject == createdTrailCubes[createdTrailCubes.Count - 1].gameObject)
		{
			createdTrailCubes.RemoveAt(createdTrailCubes.Count - 1);
			Destroy(rayCastHit.transform.gameObject);
			controller.SendMessage("UpdateUI", -1);
			oldPosition = transform.position;
			vectorToMoveTowards = transform.position + movementVector;
		}

	}

	void Respawn()
	{
		Debug.Log ("Respawn");
		vectorToMoveTowards = startingPosition;
	}
}
