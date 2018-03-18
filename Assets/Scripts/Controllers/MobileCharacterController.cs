using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileCharacterController : MonoBehaviour {

	private float rotationSpeed = 1.1f;
	public Text headingRaw;

	void Start() {
		Input.compass.enabled = true;
		Input.location.Start ();
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		Vector3 initialRotation = new Vector3 (0, Input.compass.magneticHeading, 0);
		transform.rotation = Quaternion.Euler (initialRotation);
		setHeadingDebug(initialRotation.y);
	}

	void Update() {
		float heading = Input.compass.magneticHeading;
		Quaternion vHeading = Quaternion.Euler(0, heading, 0);
		transform.rotation = Quaternion.Slerp (transform.rotation, vHeading, Time.deltaTime * rotationSpeed);

		setHeadingDebug (heading);
	}

	void setHeadingDebug(float heading) {
		headingRaw.text = "Heading: " + heading;
	}


}
