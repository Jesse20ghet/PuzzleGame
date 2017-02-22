using UnityEngine;
using System.Collections;

public class RoomFourSpotlightScripts : MonoBehaviour {

	public int maxMoveSpeed;
	public int minMoveSpeed;

	private Vector3 startingPosition;
	private Vector3 leftPosition;
	private Vector3 rightPosition;

	private float movementSpeed;

	private bool movingLeft = true;
	private bool movingRight = false;

	private GameObject[] roomFourWarningLights;

	void Start()
	{
		startingPosition = transform.position;
		leftPosition = startingPosition + new Vector3(5, 0, 0);
		rightPosition = startingPosition + new Vector3(-5, 0, 0);
		movementSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

		roomFourWarningLights = GameObject.FindGameObjectsWithTag("RoomFourWarningLight");
	}

	void Update()
	{
		if(transform.position == leftPosition && movingLeft)
		{
			movingRight = true;
			movingLeft = false;
		}
		else if(transform.position == rightPosition && movingRight)
		{
			movingLeft = true;
			movingRight = false;
		}

		if(movingLeft)
			transform.position = Vector3.MoveTowards(transform.position, leftPosition, movementSpeed * Time.deltaTime);
		else if(movingRight)
			transform.position = Vector3.MoveTowards(transform.position, rightPosition, movementSpeed * Time.deltaTime);
	}


	void OnTriggerEnter(Collider collision)
	{
		GameObject.Find("RoomFourBlock").GetComponent<MoveDownScript>().enabled = false;
		GameObject.Find("RoomFourBlock").GetComponent<MoveUpScript>().enabled = true;

		foreach(var warningLight in roomFourWarningLights)
		{
			warningLight.AddComponent<LightFlashScript>();
		}
	}
}
