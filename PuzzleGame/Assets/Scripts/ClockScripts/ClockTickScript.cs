using UnityEngine;
using System.Collections;

public class ClockTickScript : MonoBehaviour {

	public GameObject minuteHand;
	public GameObject hourHand;

	private float tickRate = .1F;
	private float nextTickTime;
	private float minuteAngle;
	private float hourAngle;

	private int minuteHandTimesTicked = 0;

	// Use this for initialization
	void Start ()
	{
		nextTickTime = Time.time + tickRate;
		minuteAngle = minuteHand.transform.localRotation.y;
		hourAngle = hourHand.transform.localRotation.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Time.time >= nextTickTime)
		{
			minuteAngle += 5;
			minuteHand.transform.localRotation = Quaternion.Euler(0, minuteAngle, 0);

			minuteHandTimesTicked++;

			if (minuteHandTimesTicked == 12)
			{
				hourAngle += 5;
				hourHand.transform.localRotation = Quaternion.Euler(0, hourAngle, 0);
				minuteHandTimesTicked = 0;
			}

			nextTickTime = Time.time + tickRate;
		}
	}
}
