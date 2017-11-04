using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	abstract public void Interact();
}
