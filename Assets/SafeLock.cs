using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeLock : MonoBehaviour {

	int numlockDegPerSec = 80;
	GameObject numlock = null;
	GameObject hinge = null;

	bool isNumlockRotating = false;
	float numlockRotateDir = 1;
	float numlockRotationTarget = 0;


	// Use this for initialization
	void Start () {
		Debug.Log ("Safe lock code is the super secret 1943");
		numlock = GameObject.Find ("numlock").gameObject;
		hinge = GameObject.Find ("hinge").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha0)) numlockRight(0);
		if(Input.GetKeyDown(KeyCode.Alpha1)) numlockRight(1);
		if(Input.GetKeyDown(KeyCode.Alpha2)) numlockRight(2);
		if(Input.GetKeyDown(KeyCode.Alpha3)) numlockRight(3);
		if(Input.GetKeyDown(KeyCode.Alpha4)) numlockRight(4);
		if(Input.GetKeyDown(KeyCode.Alpha5)) numlockRight(5);
		if(Input.GetKeyDown(KeyCode.Alpha6)) numlockRight(6);
		if(Input.GetKeyDown(KeyCode.Alpha7)) numlockRight(7);
		if(Input.GetKeyDown(KeyCode.Alpha8)) numlockRight(8);
		if(Input.GetKeyDown(KeyCode.Alpha9)) numlockRight(9);

		if (isNumlockRotating) {
			Debug.Log ("Target: " + numlockRotationTarget + ", Rotation:" + numlock.transform.rotation.eulerAngles.z);
			float rotation = numlock.transform.rotation.eulerAngles.z;
			float newRotation = rotation + numlockDegPerSec * Time.deltaTime;
			if (numlockRotationTarget > rotation && numlockRotationTarget < newRotation) { // for clockwise rotation only
				newRotation = numlockRotationTarget;
				isNumlockRotating = false;
			} else if (newRotation % 360 < rotation && newRotation % 360 > numlockRotationTarget) {
				newRotation = numlockRotationTarget;
				isNumlockRotating = false;
			}
			numlock.transform.Rotate (0, 0, newRotation - rotation);
		}
	}

	public void numlockRight(int targetNum) {
		float angleCorrection = 290;
		numlockRotationTarget = 360 - (targetNum * 360 / 10 + angleCorrection) % 360;
		numlockRotateDir = 1;
		isNumlockRotating = true;

		if (numlock.transform.rotation.eulerAngles.z > numlockRotationTarget) {
			numlock.transform.Rotate (0, 0, -360);
		}
	}

	public void hingeRight() {
		hinge.transform.Rotate (0, 0, 1000 * Time.deltaTime);
	}
}
