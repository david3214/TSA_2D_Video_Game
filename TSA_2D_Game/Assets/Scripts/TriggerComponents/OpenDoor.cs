using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
	public GameObject Door;
	public bool isOpen;

	// Use this for initialization
	void Start () {
		isOpen = Door.GetComponent<DoorScript> ().isOpen;
	}

	void Update(){
		
	}
	public void OpenDoors(){
		if (!isOpen) {
			Door.GetComponent<DoorScript> ().OpenDoor ();
			isOpen = true;
			this.enabled = false;
		}
	}




}
