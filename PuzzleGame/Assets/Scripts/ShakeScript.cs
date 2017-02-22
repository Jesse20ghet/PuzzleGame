using UnityEngine;
using System.Collections;

public class ShakeScript : MonoBehaviour {

	bool movingUp = true;
	bool movingDown = false;

	int shakeCount = 0;
	Vector3 transformStartingPosition;
	Vector3 downPosition;
	Vector3 upPosition;

	// Use this for initialization
	void Start ()
	{
		transformStartingPosition = transform.position;
		downPosition = transform.position + new Vector3(0, -.05F, 0);
		upPosition = transform.position + new Vector3(0, .05F, 0);
	}

	void Update()
	{
		if (transform.position == upPosition && movingUp)
		{
			movingDown = true;
			movingUp = false;
			shakeCount++;
		}
		else if (transform.position == downPosition && movingDown)
		{
			movingUp = true;
			movingDown = false;
			shakeCount++;
		}

		if ( movingUp)
		{
			transform.position = Vector3.MoveTowards(transform.position, upPosition, Time.deltaTime);
		}
		else if(transform.position != downPosition && !movingUp && movingDown)
		{
			transform.position = Vector3.MoveTowards(transform.position, downPosition, Time.deltaTime);
		}

		if (shakeCount == 6) // Six becaue it increments on the up and on the down
			Destroy(this);
	}
}
