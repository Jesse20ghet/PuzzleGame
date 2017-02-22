using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

	static public GameObject player;
	static private bool firstLoad = true;

	// Use this for initialization
	void Start () 
	{
		if (firstLoad)
		{
			player = Resources.Load ("Player") as GameObject;
			player = GameObject.Instantiate (player, new Vector3 (-3.55F, 4.5F, 6.22F), new Quaternion(0, 0, 0, 0)) as GameObject;
			OnLevelWasLoaded();
			player.name = "Player";

			firstLoad = false;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnLevelWasLoaded()
	{
		player.transform.position = GameObject.Find ("SpawnPoint").transform.position;
	}
}
