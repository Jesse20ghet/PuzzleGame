using UnityEngine;
using System.Collections;

public class DrawerActivatableScript : MonoBehaviour {

	bool doorOpen = false;
	OpenDrawerScript openDrawerRef;
	CloseDrawerScript closeDrawerRef;

	// Use this for initialization
	void Start ()
	{
		openDrawerRef = transform.parent.gameObject.GetComponent<OpenDrawerScript>();
		closeDrawerRef = transform.parent.gameObject.GetComponent<CloseDrawerScript>();
	}
	
	public void Activate(GameObject player)
	{
		if (!doorOpen)
		{
			openDrawerRef.enabled = true;
			closeDrawerRef.enabled = false;
		}
		else
		{
			openDrawerRef.enabled = false;
			closeDrawerRef.enabled = true;
		}


		doorOpen = !doorOpen;
	}
}
