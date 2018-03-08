using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNAttack : MonoBehaviour {
	public static float playerHealth;
	public int invincibilityTime;
	public bool takingDmg;

	public GameObject LeftBeam;
	public GameObject RightBeam;//cause lazy

	public float attackTime = .2f;
	public static bool attacking = false;
	public static bool attackOnCD = false;

	public GameObject LoseCanvas;
	// Use this for initialization
	void Start () {
		playerHealth = 3f;
		invincibilityTime = 1;
		takingDmg = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!attacking && Input.GetKeyDown(KeyCode.J) && !attackOnCD && !PauseMenu.isPaused) {
			Attack ();
		}

	}

	void dealDmg(float dmg){
		StartCoroutine (TakeDmg (invincibilityTime));
		playerHealth -= dmg;
		if (playerHealth <= 0) {
			GetComponentInParent<LoseOrWin> ().LoseGame (LoseCanvas);
		}
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

		Vector2 temp = this.GetComponent<Rigidbody2D> ().velocity;

		this.GetComponent<Rigidbody2D>().gravityScale = 0;

		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

		yield return new WaitForSeconds (time);


		this.GetComponent<Rigidbody2D>().gravityScale = 1;

		this.GetComponent<Rigidbody2D> ().velocity = temp;


		attacking = false;

		yield return new WaitForSeconds (1f);

		attackOnCD = false;

	}

}
