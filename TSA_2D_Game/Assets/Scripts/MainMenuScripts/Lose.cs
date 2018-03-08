using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lose : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		StartCoroutine (BackToMain());
	}

	IEnumerator BackToMain(){

		yield return new WaitForSeconds (3f);

		SceneManager.LoadScene (0);
	}
}
