using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNAttack : MonoBehaviour {
	public float playerHealth;
	public int invincibilityTime;
	public bool takingDmg;

	public GameObject LeftBeam;
	public GameObject RightBeam;//cause lazy

	public float attackTime = 1.0f;
	public bool attacking = false;
	public bool attackOnCD = false;
	// Use this for initialization
	void Start () {
		playerHealth = 3f;
		invincibilityTime = 1;
		takingDmg = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!attacking && Input.GetKeyDown(KeyCode.J) && !attackOnCD) {
			Attack ();
		}

	}

	void dealDmg(float dmg){
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

	void Attack(){

		if (GetComponent<PlayerMovement> ().facingLeft) {
			StartCoroutine (Attacking (attackTime));
			GameObject Weapon = Instantiate (LeftBeam, this.gameObject.transform.position, Quaternion.identity) as GameObject;
			Weapon.transform.position = transform.position;
			Weapon.GetComponentInChildren<SpriteRenderer> ().flipX = true;
		} else {
			StartCoroutine (Attacking (attackTime));
			GameObject Weapon = Instantiate (RightBeam, this.gameObject.transform.position, Quaternion.identity) as GameObject;
			Weapon.transform.position = transform.position;
		}

	}

	IEnumerator TakeDmg(int time){
		takingDmg = true;

		yield return new WaitForSeconds (time);

		takingDmg = false;
	}
	IEnumerator Attacking(float time){
		attacking = true;
		attackOnCD = true;
		yield return new WaitForSeconds (time);

		attacking = false;

		yield return new WaitForSeconds (1f);

		attackOnCD = false;
	}

}
