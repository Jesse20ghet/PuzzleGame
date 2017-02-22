using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Classes.Container;
using Assets.Classes;

public class BlockRoomControllerScriptBase : MonoBehaviour
{
	public List<CubeContainer> Cubes = new List<CubeContainer>();
	public GameObject doorToOpen;
	
	public void ToggleCube(Enumerations.CubeType cube)
	{
		foreach(var cubeToToggle in Cubes)
		{
			if(cubeToToggle.CubeType == cube)
			{
				cubeToToggle.enabled = !cubeToToggle.enabled;
				break;
			}
		}

		CheckForWin();
	}

	private void CheckForWin()
	{
		foreach(var cube in Cubes)
		{
			if (!cube.enabled)
				return;
		}

		doorToOpen.AddComponent<OpenDoorScript>();
	}
}
