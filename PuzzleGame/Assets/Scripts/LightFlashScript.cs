using UnityEngine;
using System.Collections;

public class LightFlashScript : MonoBehaviour {

	private float flashToggleTime = .5F;
	private float swapTime;
	private Light lightRef;

	// Use this for initialization
	void Start ()
	{
		lightRef = GetComponent<Light>();
		swapTime = Time.time + flashToggleTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Time.time > swapTime)
		{
			lightRef.enabled = !lightRef.enabled;

			swapTime = Time.time + flashToggleTime;
		}
	}
}
