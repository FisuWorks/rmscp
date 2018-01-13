using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCharacterController : MonoBehaviour {
	
	private float lastX;
	private float lastZ;

	void Start() {
		lastX = transform.rotation.eulerAngles.x;
		lastZ = transform.rotation.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
