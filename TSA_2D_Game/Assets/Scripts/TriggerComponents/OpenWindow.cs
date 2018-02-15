using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenWindow : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	public void LoadSceneAt(int level)
	{
		SceneManager.LoadScene(level);
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player" && Input.GetAxis("Vertical") > 0) {
			LoadSceneAt (1);
		}
	}
}
