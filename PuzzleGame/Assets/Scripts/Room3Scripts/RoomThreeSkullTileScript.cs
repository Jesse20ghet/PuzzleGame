using UnityEngine;
using System.Collections;

public class RoomThreeSkullTileScript : MonoBehaviour {

	private MoveUpScript moveUpScriptRef;
	private MoveDownScript moveDownScriptRef;

	void Start()
	{
		moveUpScriptRef = GetComponent<MoveUpScript>();
		moveDownScriptRef = GetComponent<MoveDownScript>();
	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.name == "Player")
		{
			moveUpScriptRef.enabled = true;
			moveDownScriptRef.enabled = false;
		}
	}

	void OnTriggerExit(Collider collision)
	{
		if (collision.gameObject.name == "Player")
		{
			moveUpScriptRef.enabled = false;
			moveDownScriptRef.enabled = true;
		}
	}
}
