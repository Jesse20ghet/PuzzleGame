using UnityEngine;
using System.Collections;

public class PicturePineTreeActivateScript : MonoBehaviour {

	private bool rotated = false;
	private GameObject[] treeTiles;

	// Use this for initialization
	void Start ()
	{
		treeTiles = GameObject.FindGameObjectsWithTag("Symbol-Tree");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Activate(GameObject player)
	{
		if (transform.parent.gameObject.GetComponent<PicturePineTreeRotateClockwiseScript>() != null ||
			transform.parent.gameObject.GetComponent<PicturePineTreeRotateCounterClockwiseScript>() != null)
			return;

		if (rotated)
		{
			transform.parent.gameObject.AddComponent<PicturePineTreeRotateCounterClockwiseScript>();
		}

		if (!rotated)
		{
			transform.parent.gameObject.AddComponent<PicturePineTreeRotateClockwiseScript>();
		}
		
		rotated = !rotated;

		foreach (var treeTile in treeTiles)
		{
			treeTile.SendMessage("Toggle", rotated);
		}
	}
}
