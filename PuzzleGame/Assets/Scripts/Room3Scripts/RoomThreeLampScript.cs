using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RoomThreeLampScript : MonoBehaviour {

	private Light lightSource;
	private List<GameObject> lampTiles;
	private bool isLightOn = false;

	// Use this for initialization
	void Start ()
	{
		foreach(var x in this.GetComponentsInChildren<Light>())
		{
			lightSource = x;
		}
	}

	void Awake()
	{
		lampTiles = GameObject.FindGameObjectsWithTag("Symbol-Lamp").ToList();
	}
	
	void Activate(GameObject player)
	{
		lightSource.enabled = !isLightOn;
		
		// Invert the light status
		isLightOn = !isLightOn;

		foreach(var lampTile in lampTiles)
		{
			lampTile.SendMessage("Toggle", isLightOn);
		}
	}
}
