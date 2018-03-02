using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNAttack : MonoBehaviour {
	public int playerHealth;
	public int invincibilityTime;
	public bool takingDmg;

	public GameObject beam;
	public bool attacking;
	// Use this for initialization
	void Start () {
		playerHealth = 3;
		invincibilityTime = 1;
		takingDmg = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!attacking && Input.GetKeyDown(KeyCode.J)) {
			Attack ();
		}

	}

	void dealDmg(int dmg){
		StartCoroutine (TakeDmg (invincibilityTime));
		playerHealth -= dmg;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy" && !takingDmg && this.gameObject.tag == "Player") {
			dealDmg(other.GetComponent<InteractionsWithPlayer> ().dmg);
			other.gameObject.SetActive (false);
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Enemy" && !takingDmg) {
			dealDmg(other.GetComponent<InteractionsWithPlayer> ().dmg);
			Destroy (other.gameObject);
		}
	}

	IEnumerator TakeDmg(int time){
		takingDmg = true;

		yield return new WaitForSeconds (time);

		takingDmg = false;
	}
	IEnumerator Attacking(int time){
		attacking = true;

		yield return new WaitForSeconds (time);

		attacking = false;
	}
	void Attack(){
		StartCoroutine (Attacking (3));
		GameObject Weapon = Instantiate (beam, this.gameObject.transform.position, Quaternion.identity) as GameObject;
		Weapon.transform.parent = this.gameObject.transform;
		Weapon.transform.position = transform.position;
	}
}
