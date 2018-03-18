using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class InteractionSensor : MonoBehaviour {

	private Camera mainCamera;

	[HideInInspector]
	public GameObject highlighted;


	void Start () {
		mainCamera = Camera.main;
		StartCoroutine ("DoRayCast");
		highlighted = null;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (highlighted != null) {
				Interactable i = highlighted.GetComponent<Interactable> ();
				i.Interact ();
			}
		}
	}

	void EnableOutline(GameObject go) {
		Outline outline = go.GetComponent<Outline> ();
		outline.enabled = true;
	}

	void DisableOutline(GameObject go) {
		Outline outline = go.GetComponent<Outline> ();
		outline.enabled = false;
	}

	void Highlight(GameObject go) {
		highlighted = go;
		EnableOutline (go);
	}

	void Unhighlight(GameObject go) {
		DisableOutline (go);
		highlighted = null;
	}

	IEnumerator DoRayCast() {
		for (;;) {
			// do it
			Vector3 origin = mainCamera.transform.position;
			RaycastHit hit;

			if(Physics.Raycast(origin, mainCamera.transform.forward, out hit, 200f)) {

				GameObject hitObject = hit.transform.gameObject;

				if (highlighted != null && hitObject != highlighted) {
					Unhighlight (highlighted);
				}

				if (hitObject.GetComponent<Interactable> () != null) {
					Highlight (hitObject);
				}
			}
			else if (highlighted != null) {
				Unhighlight (highlighted);
			}

			yield return new WaitForSeconds (.2f);
		}
	}
}
