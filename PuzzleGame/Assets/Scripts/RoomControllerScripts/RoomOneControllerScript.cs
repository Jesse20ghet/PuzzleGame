using UnityEngine;
using System.Collections;
using Assets.Classes.Container;

public class RoomOneControllerScript : BlockRoomControllerScriptBase
{
	// Use this for initialization
	void Start()
	{
		var redCube = new CubeContainer()
		{
			CubeType = Assets.Classes.Enumerations.CubeType.Red
		};

		Cubes.Add(redCube);
	}

	public override bool AdvancedCheck()
	{
		return true;
	}
}

