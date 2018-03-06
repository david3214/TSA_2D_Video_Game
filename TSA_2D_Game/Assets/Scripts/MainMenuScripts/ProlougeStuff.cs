using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProlougeStuff : MonoBehaviour {

	public GameObject nextPart;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			nextPart.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}
}
