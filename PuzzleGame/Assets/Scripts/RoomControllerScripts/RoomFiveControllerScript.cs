﻿using UnityEngine;
using System.Collections;
using Assets.Classes.Container;
using Assets.Classes;

public class RoomFiveControllerScript : BlockRoomControllerScriptBase
{

	// Use this for initialization
	void Start ()
	{
		var redCubeContainer = new CubeContainer() { CubeType = Enumerations.CubeType.Red };
		var blueCubeContainer = new CubeContainer() { CubeType = Enumerations.CubeType.Blue };
		var greenCubeContainer = new CubeContainer() { CubeType = Enumerations.CubeType.Green };
		var cyanCubeContainer = new CubeContainer() { CubeType = Enumerations.CubeType.Cyan };

		Cubes.Add(redCubeContainer);
		Cubes.Add(blueCubeContainer);
		Cubes.Add(greenCubeContainer);
		Cubes.Add(cyanCubeContainer);
	}
	
}
