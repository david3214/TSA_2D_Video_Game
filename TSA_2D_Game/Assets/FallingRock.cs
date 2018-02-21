using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (wait (10));
		GetComponent<Animation> ().Play();

	}

	IEnumerator wait(int seconds){
		
		yield return new WaitForSeconds (seconds);

	}
}
