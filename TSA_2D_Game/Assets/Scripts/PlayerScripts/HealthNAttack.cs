using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNAttack : MonoBehaviour {
	public int playerHealth;
	public int invincibilityTime;
	public bool takingDmg;
	// Use this for initialization
	void Start () {
		playerHealth = 100;
		invincibilityTime = 1;
		takingDmg = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void dealDmg(int dmg){
		StartCoroutine (TakeDmg (invincibilityTime));
		playerHealth -= dmg;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy" && !takingDmg) {
			dealDmg(other.GetComponent<InteractionsWithPlayer> ().dmg);
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Enemy" && !takingDmg) {
			dealDmg(other.GetComponent<InteractionsWithPlayer> ().dmg);
		}
	}

	IEnumerator TakeDmg(int time){
		takingDmg = true;

		yield return new WaitForSeconds (time);

		takingDmg = false;
	}
}
