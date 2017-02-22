using UnityEngine;
using System.Collections;

public class ApplyForceActivatableScript: MonoBehaviour {

	int timesActivated;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void Activate(GameObject player)
	{

		timesActivated = Random.Range(0, 4);

		switch (timesActivated)
		{
			case 0:
			case 1:
				GetComponent<Rigidbody>().AddForce((transform.position - player.transform.position) * 500);
				break;
			case 2:
			case 3:
				GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position) * 500);
				break;

		}
	}
}
