using UnityEngine;
using System.Collections;

public class MoveUpScript : MonoBehaviour {

	private Vector3 transformUpPosition;

	// Use this for initialization
	void Start ()
	{
		transformUpPosition = this.transform.position + new Vector3(0, 3.7F, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.MoveTowards(transform.position, transformUpPosition, 12 * Time.deltaTime);
	}
}
