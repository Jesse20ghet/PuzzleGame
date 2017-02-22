using UnityEngine;
using System.Collections;

public class MoveDownScript : MonoBehaviour {

	private Vector3 transformDownPosition;

	// Use this for initialization
	void Start()
	{
		transformDownPosition = this.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, transformDownPosition, 8 * Time.deltaTime);
	}
}
