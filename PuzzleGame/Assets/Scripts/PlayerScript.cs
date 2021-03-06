﻿using UnityEngine;
using System.Collections;
using System;

public class PlayerScript : MonoBehaviour {

	private const float RAY_CAST_LENGTH = 5;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		var hitObject = CastMainCameraRay();

		if (hitObject != null)
		{
			Debug.Log("Looking At: " + hitObject.transform.name);
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			if (hitObject == null)
				return;

			if(hitObject.transform.tag == "Activatable")
			{
				hitObject.gameObject.SendMessage("Activate", gameObject);
			}
		}
		if(Input.GetKeyUp(KeyCode.E))
		{
			if (hitObject == null)
				return;

			if(hitObject.transform.tag == "Activatable")
			{
				try
				{
					hitObject.gameObject.SendMessage("ActivateTwo", gameObject);
				}
				catch(Exception ex)
				{
					
				}
			}

		}
	}

	private Transform CastMainCameraRay()
	{
		RaycastHit mainRaycast;
		Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out mainRaycast, RAY_CAST_LENGTH);

		return mainRaycast.transform;
	}
}
