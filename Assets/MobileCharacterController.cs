using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileCharacterController : MonoBehaviour {
	
	private float lastX;
	private float lastZ;
	private Vector3 position;

	void Start() {
		lastX = transform.rotation.eulerAngles.x;
		lastZ = transform.rotation.eulerAngles.z;
		position = transform.position;
		Input.compass.enabled = true;
		Input.location.Start ();
	}


	void Update () {
		transform.SetPositionAndRotation(position, Quaternion.Euler(0, Input.compass.trueHeading, 0));
	}
}
