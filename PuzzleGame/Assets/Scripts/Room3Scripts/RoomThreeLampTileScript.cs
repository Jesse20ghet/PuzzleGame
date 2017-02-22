using UnityEngine;
using System.Collections;

public class RoomThreeLampTileScript : MonoBehaviour {

	private bool isLightOn;

	private MoveUpScript moveUpScriptRef;
	private MoveDownScript moveDownScriptRef;

	// Use this for initialization
	void Start ()
	{
		moveUpScriptRef = GetComponent<MoveUpScript>();
		moveDownScriptRef = GetComponent<MoveDownScript>();
	}

	void OnTriggerEnter(Collider collision)
	{
		Debug.Log("On Trigger Enter: " + collision.gameObject.name);

		if (!isLightOn && collision.gameObject.name == "Player")
		{
			moveUpScriptRef.enabled = true;
			moveDownScriptRef.enabled = false;
		}
	}

	void OnTriggerExit(Collider collision)
	{
		Debug.Log("On Trigger Exit: " + collision.gameObject.name);

		if (!isLightOn && collision.gameObject.name == "Player")
		{
			moveUpScriptRef.enabled = false;
			moveDownScriptRef.enabled = true;
		}
	}

	public void Toggle(bool toggleValue)
	{
		isLightOn = toggleValue;
	}
}
