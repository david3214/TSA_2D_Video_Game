using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
	public GameObject GreenDoor;
	public GameObject BlueDoor;
	public GameObject RedDoor;
	bool redDoorOpen = false;
	bool blueDoorOpen = false;
	bool greenDoorOpen = false;

	// Use this for initialization
	void Start () {
		
	}

	void Update(){

	}
	public void OpenGreenDoor(){
		if (!greenDoorOpen) {
			GreenDoor.GetComponent<Animation> ().Play ();
			greenDoorOpen = true;
		}
	}
	public void OpenRedDoor(){
		if (!redDoorOpen) {
			RedDoor.GetComponent<Animation> ().Play ();
			redDoorOpen = true;
		}
	}
	public void OpenBlueDoor(){
		if (!blueDoorOpen) {
			BlueDoor.GetComponent<Animation> ().Play ();
			blueDoorOpen = true;
		}
	}



}
