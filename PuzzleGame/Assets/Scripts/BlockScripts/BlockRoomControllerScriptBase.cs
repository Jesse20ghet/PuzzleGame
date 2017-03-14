using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Assets.Classes.Container;
using Assets.Classes;
using System;

public class BlockRoomControllerScriptBase : MonoBehaviour
{
	public List<CubeContainer> Cubes = new List<CubeContainer>();
	public GameObject doorToOpen;
	public int RequiredCubes = 0;
	public int currentTrailCubes;

	public string RoomName;

	private Text roomNameText;
	private Text percentageText;

	private Color successColor;
	private Color failureColor;

	void Awake()
	{
		//roomNameText = GameObject.Find("RoomNameText").GetComponent<Text>();
		//percentageText = GameObject.Find("PercentText").GetComponent<Text>();

		//successColor = new Color(0, 255, 0);
		//failureColor = new Color(255, 0, 0);
	}

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

	void OnTriggerEnter(Collider other)
	{
		UpdateUI();
	}

	public void UpdateUI(int? i = null)
	{
		if (i.HasValue)
			currentTrailCubes += i.Value;

		roomNameText.text = RoomName;
		percentageText.text = CreateRequiredCubeCountString();

		if (PercentageCheckAfterSpawn())
			percentageText.color = successColor;
		else
			percentageText.color = failureColor;
	}

	private string CreateRequiredCubeCountString()
	{
		var cubesInRoom = GetCubesInRoom();
		return cubesInRoom + " / " + RequiredCubes;
	}
	private void CheckForWin()
	{
		if (BasicCheck() && PercentageCheckBeforeSpawn() && AdvancedCheck())
			Win();
	}

	private bool BasicCheck()
	{
		foreach (var cube in Cubes)
		{
			if (!cube.enabled)
				return false;
		}

		return true;
	}

	private bool PercentageCheckAfterSpawn()
	{
		var cubesCreated = GetCubesInRoom();
		return cubesCreated >= (RequiredCubes); // -1 because last cube hasn't been counted for yet
	}

	private bool PercentageCheckBeforeSpawn()
	{
		var cubesCreated = GetCubesInRoom();
		return cubesCreated >= (RequiredCubes - 1); // -1 because last cube hasn't been counted for yet
	}

	private int GetCubesInRoom()
	{
		var localCount = 0;

		foreach (var cube in Cubes)
		{
			localCount++; // Count once for the regular cube
		}

		return localCount + currentTrailCubes;
	}

	public virtual bool AdvancedCheck()
	{
		return true;
	}

	public virtual void Win()
	{
		doorToOpen.AddComponent<OpenDoorScript>();

		Debug.Log("WIN! - " + transform.name);
	}
}
