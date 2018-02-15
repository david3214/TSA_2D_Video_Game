using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	public void LoadSceneAt(int level)
	{
		SceneManager.LoadScene(level);
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player" && Input.GetAxis("Vertical") > 0 && isOpen) {
			//if (){

			//}
			LoadSceneAt (2);
		}
	}
}
