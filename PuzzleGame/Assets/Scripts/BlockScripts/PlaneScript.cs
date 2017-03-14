using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaneScript : MonoBehaviour
{
	public GameObject roomController;
	public GameObject cube;
	public Assets.Classes.Enumerations.CubeType cubeType;
	public List<GameObject> walls = new List<GameObject>();

	void OnTriggerEnter(Collider collision)
	{
		Debug.Log("On Trigger Enter: " + collision.gameObject.name);

		if (collision.gameObject == cube)
		{
			roomController.GetComponent<BlockRoomControllerScriptBase>().ToggleCube(cubeType);
			UpdateWalls(false);
		}
	}

	void OnTriggerExit(Collider collision)
	{
		Debug.Log("On Trigger Exit: " + collision.gameObject.name);

		if (collision.gameObject == cube)
		{
			roomController.GetComponent<BlockRoomControllerScriptBase>().ToggleCube(cubeType);
			UpdateWalls(true);
		}
	}

	void UpdateWalls(bool status)
	{
		foreach(var wall in walls)
		{
			wall.SetActive(status);
		}
	}
}