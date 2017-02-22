using UnityEngine;
using System.Collections;

public class RoomThreeBlocksControllerScript : MonoBehaviour {

	bool greenCubeToggle = false;
	bool redCubeToggle = false;
	bool blueCubeToggle = false;
	GameObject roomTwoDoor;

	void Start()
	{
		roomTwoDoor = GameObject.Find("RoomThreeDoorContainer");
	}

	public void ToggleGreenCube(bool newState)
	{
		greenCubeToggle = newState;
		CheckForWin();
	}

	public void ToggleBlueCube(bool newState)
	{
		blueCubeToggle = newState;
		CheckForWin();
	}

	public void ToggleRedCube(bool newState)
	{
		redCubeToggle = newState;
		CheckForWin();
	}

	private void CheckForWin()
	{
		if (redCubeToggle && greenCubeToggle && blueCubeToggle)
		{
			roomTwoDoor.AddComponent<OpenDoorScript>();
		}
	}
}
