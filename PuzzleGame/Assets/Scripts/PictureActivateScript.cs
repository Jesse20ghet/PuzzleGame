using UnityEngine;
using System.Collections;

public class PictureActivateScript : MonoBehaviour {

	public void Activate(GameObject player)
	{
		if(transform.parent.gameObject.GetComponent<ShakeScript>() == null)
			transform.parent.gameObject.AddComponent<ShakeScript>();
	}
}
