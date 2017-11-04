using System;
using UnityEngine;

public class SafeInteract : Interactable
{
	void Start() {}

	override public void Interact() {
		Debug.Log ("Interacting with safe!");
	}
}

