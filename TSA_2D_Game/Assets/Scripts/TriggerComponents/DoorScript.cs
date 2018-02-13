using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	public bool isOpen;

	// Use this for initialization
	void Awake () {
		isOpen = false;

	}
	void Update(){
		
	}
	
	// Update is called once per frame
	public void OpenDoor(){
		isOpen = true;
		GetComponent<SpriteRenderer> ().color = Color.black;
	}
}
