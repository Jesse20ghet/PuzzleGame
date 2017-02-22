using UnityEngine;
using System.Collections;

public class RoomFourExitRoomScript : MonoBehaviour {

	private GameObject[] roomFourWarningLights;

	void Start()
	{
		roomFourWarningLights = GameObject.FindGameObjectsWithTag("RoomFourWarningLight");
	}

	void OnTriggerEnter(Collider collision)
	{
		GameObject.Find("RoomFourBlock").GetComponent<MoveDownScript>().enabled = true;
		GameObject.Find("RoomFourBlock").GetComponent<MoveUpScript>().enabled = false;

		foreach (var warningLight in roomFourWarningLights)
		{
			if (warningLight.GetComponent<LightFlashScript>() != null)
			{
				warningLight.GetComponent<Light>().enabled = false;
				Destroy(warningLight.GetComponent<LightFlashScript>());
			}
		}
	}
}
