using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NotificationTextScript : MonoBehaviour {

	private Text textRef;

	private float timeBetweenFades = .1F;
	private float nextFadeTime;

	private float timeBeforeFade = 3.0F;
	private float timeBeforeFadeValue;

	// Use this for initialization
	void Start ()
	{
		textRef = GameObject.Find("NotificationText").GetComponent<Text>();
		textRef.color = new Color(textRef.color.r, textRef.color.g, textRef.color.b, 1);
		timeBeforeFadeValue = Time.time + timeBeforeFade;
		nextFadeTime = Time.time + timeBeforeFade;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Time.time > timeBeforeFadeValue && Time.time > nextFadeTime)
		{
			Debug.Log(textRef.color.a);

			Color x = new Color(textRef.color.r, textRef.color.g, textRef.color.b, textRef.color.a - .05F);

			textRef.color = x;

			nextFadeTime = Time.time + timeBetweenFades;

			if (x.a < 0)
			{
				textRef.text = "";
				Destroy(this);
			}
		}
	}
}
