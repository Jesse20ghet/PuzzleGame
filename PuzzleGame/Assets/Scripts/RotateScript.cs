using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

	public float smooth = 1f;
	private Quaternion targetRotation;
	private bool activated = false;

	// Use this for initialization
	void Start ()
	{
		targetRotation = transform.parent.transform.rotation *= Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime); ;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.parent.transform.rotation = Quaternion.Lerp(transform.parent.transform.rotation, targetRotation, smooth * Time.deltaTime);
	}


}
