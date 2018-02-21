using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour {
	public bool isOpen;
	public Item thisDoorsKey;
	public int thisDoorsNumber;
	public string thisDoorsKeyName;
	public GameObject connectedDoor;
	// Use this for initialization
	void Awake () {
		

		if (name == "LockedDoor") {
			
			isOpen = false;
			string substring = name.Substring (5, 1);
			thisDoorsNumber = int.Parse (substring);
			thisDoorsKeyName = name + " Key";
			thisDoorsKey = new Item (thisDoorsKeyName, thisDoorsNumber);

		} else {
			isOpen = true;
			thisDoorsNumber = 0;
			thisDoorsKeyName = "";
			thisDoorsKey = null;
		}

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
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.W) && isOpen) {
			other.gameObject.transform.position = connectedDoor.transform.position;
		}
		if (other.tag == "Player" && !isOpen) {
			if(other.GetComponent<PlayerMovement> ().playerInv.hasItem (thisDoorsKey)){
				OpenDoor ();
				other.GetComponent<PlayerMovement> ().playerInv.removeItem (thisDoorsKey);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.W) && isOpen) {
			other.gameObject.transform.position = connectedDoor.transform.position;
		}
		if (other.tag == "Player" && !isOpen) {
			if(other.GetComponent<PlayerMovement> ().playerInv.hasItem (thisDoorsKey)){
				OpenDoor ();
				other.GetComponent<PlayerMovement> ().playerInv.removeItem (thisDoorsKey);
			}
		}
	}
}
