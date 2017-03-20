using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class MoveBlockScript : MonoBehaviour {

	public List<GameObject> createdTrailCubes = new List<GameObject>();
	public GameObject controller;
	public static int CurrentCubes = 1;

	private float inLineCheckDistance = .1F;

	float movementLength;
	float movementCheckLength;
	float movementSpeed = 4f;
	Vector3 vectorToMoveTowards;
	bool isMoving;
	Vector3 startingPosition;

	GameObject trailCube;
	GameObject cornerTrailCube;

	bool spawnCube;
	Vector3 oldPosition;

	bool resettingToTrailCube = false;
	bool lastCube = false;
	GameObject resetTrailCube;

	private Animator animatorRef;

	// Use this for initialization
	void Start () 
	{
		vectorToMoveTowards = transform.position;
		movementLength = transform.GetComponent<BoxCollider> ().bounds.extents.x * 2;
		movementCheckLength = movementLength * 1.4F;
		isMoving = false;
		startingPosition = transform.position;

		animatorRef = GetComponent<Animator>();

		if (transform.name.Contains("Red"))
		{
			trailCube = (GameObject)Resources.Load("TrailCubes/RedTrailCube");
			cornerTrailCube = (GameObject)Resources.Load("TrailCubes/RedTrailCornerPiece");
		}

		if (transform.name.Contains("Green"))
		{
			trailCube = (GameObject)Resources.Load("TrailCubes/GreenTrailCube");
			cornerTrailCube = (GameObject)Resources.Load("TrailCubes/GreenTrailCornerPiece");
		}

		if (transform.name.Contains("Blue"))
		{
			trailCube = (GameObject)Resources.Load("TrailCubes/BlueTrailCube");
			cornerTrailCube = (GameObject)Resources.Load("TrailCubes/BlueTrailCornerPiece");
		}

		if (transform.name.Contains("Cyan"))
		{
			trailCube = (GameObject)Resources.Load("TrailCubes/CyanTrailCube");
			cornerTrailCube = (GameObject)Resources.Load("TrailCubes/CyanTrailCornerPiece");
		}

		if (transform.name.Contains("Orange"))
		{
			trailCube = (GameObject)Resources.Load("TrailCubes/OrangeTrailCube");
			cornerTrailCube = (GameObject)Resources.Load("TrailCubes/OrangeTrailCornerPiece");
		}

		if (transform.name.Contains("Yellow"))
		{
			trailCube = (GameObject)Resources.Load("TrailCubes/YellowTrailCube");
			cornerTrailCube = (GameObject)Resources.Load("TrailCubes/YellowTrailCornerPiece");
		}

		if (transform.name.Contains("Pink"))
		{
			trailCube = (GameObject)Resources.Load("TrailCubes/PinkTrailCube");
			cornerTrailCube = (GameObject)Resources.Load("TrailCubes/PinkTrailCornerPiece");
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (resettingToTrailCube) // The cube is being reset to an earlier trail cube's position
		{
			if(vectorToMoveTowards == transform.position)
			{
				if (lastCube)
				{
					resettingToTrailCube = false;
					resetTrailCube = null;
					movementSpeed = 4;
					return;
				}

				if (createdTrailCubes[createdTrailCubes.Count - 1] == resetTrailCube)
					lastCube = true;

				vectorToMoveTowards = createdTrailCubes[createdTrailCubes.Count - 1].transform.position;

				vectorToMoveTowards = createdTrailCubes[createdTrailCubes.Count - 1].transform.position;
				Destroy(createdTrailCubes[createdTrailCubes.Count - 1]);
				createdTrailCubes.RemoveAt(createdTrailCubes.Count - 1);
			}
			else
			{
				transform.position = Vector3.MoveTowards(transform.position, vectorToMoveTowards, movementSpeed * Time.deltaTime);
			}
		}
		else
		{
			if (vectorToMoveTowards == transform.position)
			{
				if (spawnCube)
				{
					spawnCube = false;
					var x = CalculateTrailCubeToSpawn();
					//var x = (GameObject)GameObject.Instantiate(cornerTrailCube, oldPosition, transform.rotation);
					x.name = transform.name + "TrailBox";
					x.transform.parent = transform.parent.transform;
					x.transform.tag = "Activatable";

					createdTrailCubes.Add(x);
					//if(controller != null)
					//	controller.SendMessage("UpdateUI", 1);
				}

				isMoving = false;
			}
			else
			{
				transform.position = Vector3.MoveTowards(transform.position, vectorToMoveTowards, movementSpeed * Time.deltaTime);
				isMoving = true;
			}
		}
	}

	private GameObject CalculateTrailCubeToSpawn()
	{
		GameObject cubeToSpawn;

		if (createdTrailCubes.Count == 0) // There are no other cubes, So it has to be a straight line
		{
			cubeToSpawn = (GameObject)GameObject.Instantiate(trailCube, oldPosition, transform.rotation);
			cubeToSpawn.GetComponent<TrailCubeScript>().LookAtParent(this.transform.gameObject);
		}
		else
		{
			var lastlyCreatedCube = createdTrailCubes[createdTrailCubes.Count - 1];

			// Checking to see if the cube is a straight line(Or as straight as Unity remembers) from its last created trail cube
			if (lastlyCreatedCube.transform.localPosition.x == transform.localPosition.x||
				lastlyCreatedCube.transform.localPosition.z == transform.localPosition.z)
			{
				cubeToSpawn = (GameObject)GameObject.Instantiate(trailCube, oldPosition, transform.rotation);
				cubeToSpawn.GetComponent<TrailCubeScript>().LookAtParent(this.transform.gameObject);
			}
			else
			{
				cubeToSpawn = (GameObject)GameObject.Instantiate(cornerTrailCube, oldPosition, transform.rotation);
				cubeToSpawn.GetComponent<CornerTrailCubeScript>().SetTrailCubeRotation(this.transform.gameObject, createdTrailCubes.Last(), movementCheckLength);
			}

		}

		return cubeToSpawn;
	}

	void Activate(GameObject player)
	{
		if (isMoving || resettingToTrailCube)
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
		else if (createdTrailCubes.Count > 0 && rayCastHit.transform.gameObject == createdTrailCubes.Last().gameObject)
		{
			createdTrailCubes.RemoveAt(createdTrailCubes.Count - 1);
			Destroy(rayCastHit.transform.gameObject);

			//if(controller != null)
			//	controller.SendMessage("UpdateUI", -1);

			oldPosition = transform.position;
			vectorToMoveTowards = transform.position + movementVector;
		}
		else
		{
			animatorRef.SetTrigger("BadDirection");
		}

	}

	public void ResetToTrailCube(GameObject trailCube)
	{
		resettingToTrailCube = true;
		resetTrailCube = trailCube;

		lastCube = false; // Reset last cube flag

		if (trailCube == createdTrailCubes[createdTrailCubes.Count - 1])
			lastCube = true;

		vectorToMoveTowards = createdTrailCubes[createdTrailCubes.Count - 1].transform.position;
		Destroy(createdTrailCubes[createdTrailCubes.Count - 1]);
		createdTrailCubes.RemoveAt(createdTrailCubes.Count - 1);
		movementSpeed = 8;
	}

	void Respawn()
	{
		Debug.Log ("Respawn");
		vectorToMoveTowards = startingPosition;
	}
}
