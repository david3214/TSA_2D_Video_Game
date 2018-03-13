using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour {
	public Sprite sprite1;
	public Sprite sprite2;

	public bool isOpen;
	public Item thisDoorsKey;
	public int thisDoorsNumber;
	public string thisDoorsKeyName;
	public GameObject connectedDoor;

	public GameObject LockedMessage;

	public GameObject playerCam = null;
	public GameObject BossCam = null;
	public GameObject AS;
	// Use this for initialization
	void Awake () {

		if (name != "LowerDoor" && name != "UpperDoor" && name != "BossDoor" && name != "LowerDiningDoor") {
			
			isOpen = false;
			GetComponent<SpriteRenderer> ().sprite = sprite2;

			thisDoorsNumber = int.Parse (name.Substring(11, 1));
			thisDoorsKeyName = name + " Key";
			thisDoorsKey = new Item (thisDoorsKeyName, thisDoorsNumber);

		} else {
			GetComponent<SpriteRenderer> ().sprite = sprite1;

			isOpen = true;
			thisDoorsNumber = 0;
			thisDoorsKeyName = "";
			thisDoorsKey = null;
		}

	}
	
	// Update is called once per frame
	public void OpenDoor(){
		isOpen = true;
		GetComponent<SpriteRenderer> ().sprite = sprite1;
	}
	public void LoadSceneAt(int level)
	{
		SceneManager.LoadScene(level);
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.W) && !isOpen) {
			StartCoroutine (Locked());
		}
		if (other.tag == "Player" && !isOpen) {
			if(other.GetComponent<InventoryNItems> ().playerInv.hasItem (thisDoorsKey)){
				OpenDoor ();
				other.GetComponent<InventoryNItems> ().playerInv.removeItem (thisDoorsKey);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.W) && !isOpen && name != "BossDoor") {
			StartCoroutine (Locked());
		}
		if (other.tag == "Player" && !isOpen) {
			if (other.GetComponent<InventoryNItems> ().playerInv.hasItem (thisDoorsKey)) {
				OpenDoor ();
				other.GetComponent<InventoryNItems> ().playerInv.removeItem (thisDoorsKey);
			}
		}
	}
	IEnumerator Locked(){
		LockedMessage.SetActive (true);

		yield return new WaitForSeconds (3f);

		LockedMessage.SetActive (false);
	}

	public void BossDoorStuff(){
		isOpen = false;

		thisDoorsNumber = 2;
		thisDoorsKeyName = name + " Key";
		thisDoorsKey = new Item (thisDoorsKeyName, thisDoorsNumber);

		GetComponent<SpriteRenderer> ().sprite = sprite2;
		GetComponent<BossArenaStuff> ().playerEnter ();


		playerCam.SetActive(false);
		BossCam.SetActive(true);
	}

	public void DiningDoor(){
		AS.GetComponent<VolumeScript> ().ToMain ();
	}
}
