using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class InteractionSensor : MonoBehaviour {

	private Camera mainCamera;
	private Coroutine raycastCoroutine;

	[HideInInspector]
	public GameObject highlighted;

	void Start () {
		mainCamera = Camera.main;
		raycastCoroutine = StartCoroutine ("DoRayCast");
		highlighted = null;
	}

	void Update () {
		
	}

	void EnableOutline(GameObject go) {
		Outline outline = go.GetComponent<Outline> ();
		outline.enabled = true;
	}

	void DisableOutline(GameObject go) {
		Outline outline = go.GetComponent<Outline> ();
		outline.enabled = false;
	}

	IEnumerator DoRayCast() {
		for (;;) {
			// do it
			Vector3 origin = camera.transform.position;
			Vector3 direction = camera.transform.rotation.eulerAngles;
			RaycastHit hit;

			if(Physics.Raycast(origin, direction, out hit, 10f)) {

				GameObject hitObject = hit.transform.gameObject;
				if (hitObject != null) {
					Debug.Log (hitObject);
				}

				if (hitObject.GetComponent<Interactable> () != null) {
					Debug.Log ("Interactable thing too!");

					if (highlighted != null) {
						DisableOutline (highlighted);
					}
					highlighted = hitObject;
					EnableOutline (highlighted);
				} 
			}
			else {
				Debug.Log ("hit nothing");
			}

			yield return new WaitForSeconds (.2f);
		}
	}
}
