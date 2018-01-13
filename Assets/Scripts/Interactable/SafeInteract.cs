using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeInteract : Interactable
{
	enum State {
		IDLE,
		INIT,
		INTERACTION,
		END
	}

	public Transform interactionPosition;
	public int flightTime = 2;

	private GameObject safe;
	private Transform numlock;

	private Camera mainCamera;
	private Camera interactionCamera;

	private State state = State.IDLE;
	private IEnumerator coroutine;

	private bool mouseLeftDown = false;
	private float lastMouseX = -1;
	private float lastMouseY = -1;


	public void Start() {
		safe = gameObject;
		numlock = safe.transform.Find("numlock");
		mainCamera = Camera.main;
	}

	override public void Interact() {
		Debug.Log ("Interacting with safe!");

		if (interactionCamera == null) {
			interactionCamera = Instantiate (Camera.main);
		}

		interactionCamera.transform.SetPositionAndRotation (mainCamera.transform.position, mainCamera.transform.rotation);

		mainCamera.enabled = false;
		mainCamera.GetComponent<AudioListener> ().enabled = false;
		interactionCamera.enabled = true;
		interactionCamera.GetComponent<AudioListener> ().enabled = true;

		coroutine = FlyCameraTo (interactionCamera, interactionPosition.position, interactionPosition.rotation, flightTime);
		state = State.INIT;
		StartCoroutine (coroutine);
	}
		

	IEnumerator FlyCameraTo(Camera cam, Vector3 position, Quaternion rotation, float seconds) {
		Vector3 startPosition = cam.transform.position;
		Quaternion startRotation = cam.transform.rotation;

		float i = 0f;
		float rate = 1f / seconds;

		while (i < 1f) {
			i += Time.deltaTime * rate;
			interactionCamera.transform.position = Vector3.Lerp (startPosition, position, i);
			interactionCamera.transform.rotation = Quaternion.Lerp (startRotation, rotation, i);

			yield return null;
		}

		onFinishFly ();
			
	}


	void onFinishFly() {
		if (state == State.END) {
			state = State.IDLE;
			mainCamera.enabled = true;
			mainCamera.GetComponent<AudioListener> ().enabled = true;
			interactionCamera.enabled = false;
			interactionCamera.GetComponent<AudioListener> ().enabled = false;
		}
		else if(state == State.INIT) {
			state = State.INTERACTION;
		}
	}

	void Update() {
		float delta = Time.deltaTime;

		if (state == State.INIT) {
		}
		else if (state == State.INTERACTION) {
			// Check for inputs etc.
			InteractionCheck();
		}
		else if (state == State.END) {
			
		}

	}

	void InteractionCheck() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			state = State.END;
			coroutine = FlyCameraTo(interactionCamera, mainCamera.transform.position, mainCamera.transform.rotation, flightTime);
			StartCoroutine (coroutine);
		}
		else if (!mouseLeftDown) {
			if (Input.GetMouseButtonDown (0)) {
				mouseLeftDown = true;
				lastMouseX = Input.mousePosition.x;
				lastMouseY = Input.mousePosition.y;
			}
		}
		else {
			float currentMouseX = Input.mousePosition.x;
			float currentMouseY = Input.mousePosition.y;
			float zRot = currentMouseX - lastMouseX;
			numlock.transform.RotateAround (Vector3.zero, Vector3.up, zRot);

			lastMouseX = currentMouseX;
			lastMouseY = currentMouseY;
		}
	}

}

