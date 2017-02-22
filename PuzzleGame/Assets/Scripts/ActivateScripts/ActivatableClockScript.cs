using UnityEngine;
using System.Collections;

public class ActivatableClockScript : MonoBehaviour {

	public ClockTickScript clockTickScript;
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void Activate()
	{
		clockTickScript.enabled = !clockTickScript.enabled;
	}
}
