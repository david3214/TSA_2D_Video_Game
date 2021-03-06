﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody2D rb;
	public float moveSpeed = 7.0f;
	public float jumpSpeed = 10f;
	public float climbSpeed = 2.0f;
	public float rbVelocity = 0;
	public bool isJumping = false;
	public bool grounded = false;
	public bool canMoveLeft = true;
	public bool canMoveRight = true;
	public float groundRadius = 0.2f;
	public bool OnLadder = false;

	public bool canDoubleJump = true;
	public bool hasDoubleJump = true;

	public bool facingLeft = false;

	public GameObject Door;

	// Use this for initialization
	void Awake () {

		rb = GetComponent<Rigidbody2D> ();
		Door = null;
	}

	// Update is called once per frame
	void FixedUpdate () {
		rbVelocity = rb.velocity.y;
		if (rb.velocity.y > 5) {
			isJumping = true;
		} else {
			isJumping = false;
		}

		if (rb.velocity.y < 5 && !HealthNAttack.attacking) {
			rb.gravityScale = 2;
		} else if(rb.velocity.y >= 0 && !HealthNAttack.attacking) {
			rb.gravityScale = 1;
		}
		if (Door != null && Input.GetKeyDown(KeyCode.W)) {
			if (Door.GetComponent<DoorScript> ().isOpen) {
				transform.position = Door.GetComponent<DoorScript>().connectedDoor.transform.position;
				if (Door.GetComponent<DoorScript> ().connectedDoor.name == "BossDoor") {
					Door.GetComponent<DoorScript> ().connectedDoor.GetComponentInChildren<DoorScript> ().BossDoorStuff ();
				}
				else if (Door.GetComponent<DoorScript> ().connectedDoor.name == "DiningDoor") {
					Door.GetComponent<DoorScript> ().connectedDoor.GetComponentInChildren<DoorScript> ().DiningDoor ();
				}
			}
		}

		if (OnLadder && Input.GetKey (KeyCode.W)) {
			rb.velocity = new Vector2 (rb.velocity.x, climbSpeed);
		}

		if (!HealthNAttack.attacking)
        {
            movePlayer();
        }	
	}

	void movePlayer()
	{
			float x = Input.GetAxis ("Horizontal");
			float y = Input.GetAxis ("Jump");
			if (grounded) {
				if (y > 0) {
					rb.velocity = new Vector2 (rb.velocity.x, y * jumpSpeed);
		
				}
			} else if (canDoubleJump && !isJumping && hasDoubleJump) {
				if (y > 0) {
					rb.velocity = new Vector2 (rb.velocity.x, y * jumpSpeed);
					canDoubleJump = false;

				}
			}
			if (x < 0 && canMoveLeft) {
				if (!facingLeft) {
					Flip ();
				}
				rb.velocity = new Vector2 (x * moveSpeed, rb.velocity.y);

			} else if (x > 0 && canMoveRight) {
				if (facingLeft) {
					Flip ();
				}
				rb.velocity = new Vector2 (x * moveSpeed, rb.velocity.y);

			}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Ground") {
			grounded = true;
		}
		if (other.tag == "Platform") {
			if (rb.velocity.y > 0) {
				other.gameObject.GetComponent<ValuesForDisablePlat>().parent.GetComponent<BoxCollider2D>().enabled = false;
			} else {
				other.gameObject.GetComponent<ValuesForDisablePlat>().parent.GetComponent<BoxCollider2D>().enabled = true;
			}
		}
		if (other.tag == "Door") {
			Door = other.gameObject;
		}
		if (other.tag == "Ladder") {
			grounded = true;
			OnLadder = true;
		}

			

	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Ground" || other.tag == "Platform" ) {
			grounded = false;
			canDoubleJump = true;
		}
		else if (other.tag == "Wall") {
			if (rb.position.x > other.GetComponent<Transform> ().position.x) {
				canMoveLeft = true;
			}
			else if (rb.position.x < other.GetComponent<Transform> ().position.x) {
				canMoveRight = true;
			}
		}
		if (other.tag == "Door") {
			Door = null;
		}
		if (other.tag == "Ladder") {
			grounded = false;
			OnLadder = false;
		}

			
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Wall") {
			if (rb.position.x > other.GetComponentInParent<Transform> ().position.x) {
				canMoveLeft = false;
			}
			else if (rb.position.x < other.GetComponentInParent<Transform> ().position.x) {
				canMoveRight = false;
			}
		}
		if (other.tag == "Ground" ||  other.tag == "Platform") {
			
			grounded = true;
			canDoubleJump = true;

		}
		if (other.tag == "Door") {
			Door = other.gameObject;
		}
		if (other.tag == "Ladder") {
			grounded = true;
			OnLadder = true;
		}
	}
	void Flip(){
		if (facingLeft) {
			GetComponent<SpriteRenderer> ().flipX = false;
			facingLeft = false;
		} else {
			GetComponent<SpriteRenderer> ().flipX = true;
			facingLeft = true;
		}
	}
		

}



