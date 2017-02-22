using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SquareKeyScript : MonoBehaviour {

	private GameObject gameObjectText;

	void Awake()
	{
		gameObjectText = GameObject.Find("NotificationText");
	}

	public void Activate(GameObject player)
	{
		gameObjectText.GetComponent<Text>().text = "Square Key Acquired!";
		gameObjectText.AddComponent<NotificationTextScript>();
		Destroy(transform.parent.gameObject);
	}
}
