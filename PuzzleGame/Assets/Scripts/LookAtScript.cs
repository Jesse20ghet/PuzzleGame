using UnityEngine;
using System.Collections;

public class LookAtScript : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start ()
	{
		transform.position += new Vector3(0, transform.GetComponent<BoxCollider>().bounds.extents.x, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (player == null)
			player = GameObject.Find("Player");

		transform.LookAt(player.transform, Vector3.up);
	}
}
