using UnityEngine;
using System.Collections;

public class PlaneScript : MonoBehaviour
{
	public GameObject roomController;
	public GameObject cube;
	public Assets.Classes.Enumerations.CubeType cubeType;

	void OnTriggerEnter(Collider collision)
	{
		Debug.Log("On Trigger Enter: " + collision.gameObject.name);

		if (collision.gameObject == cube)
			roomController.GetComponent<BlockRoomControllerScriptBase>().ToggleCube(cubeType);
	}

	void OnTriggerExit(Collider collision)
	{
		Debug.Log("On Trigger Exit: " + collision.gameObject.name);

		if (collision.gameObject == cube)
			roomController.GetComponent<BlockRoomControllerScriptBase>().ToggleCube(cubeType);
	}
}