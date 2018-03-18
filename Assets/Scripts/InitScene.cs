using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InitScene : MonoBehaviour {
	/* InitScene is for initialisation of the scene, especially for platform-dependent script attachment */

	void Awake() {
		GameObject player = GameObject.Find ("Le Hahmo");
		if (player == null) {
			Debug.LogError ("Could not find player character [GameObject.Find(\"Le Hahmo\")], failed to initialise.]");
		}
		else {
			/*
			#if UNITY_EDITOR
			player.GetComponent<FirstPersonController>().enabled = true;
			player.GetComponent<MobileCharacterController>().enabled = false;
			#endif

			#if UNITY_ANDROID
			player.GetComponent<FirstPersonController>().enabled = false;
			player.GetComponent<MobileCharacterController>().enabled = true;
			#endif
			*/
		}
	}
}
