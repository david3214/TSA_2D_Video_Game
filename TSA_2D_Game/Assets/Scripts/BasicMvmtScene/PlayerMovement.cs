using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody2D rb;
	public float moveSpeed = 7.0f;
	public float jumpSpeed = 7.5f;
	public float jumpForce = 2.0f;
	public float slideSpeed = -3.0f;

	public bool grounded = false;
	public bool canMoveLeft = true;
	public bool canMoveRight = true;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public bool isJumping = false;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (rb.velocity.y > 0) {
			isJumping = true;
		} else {
			isJumping = false;
		}
		//grounded = Physics2D.OverlapArea (new Vector2 (	), new Vector2 (), whatIsGround);
		movePlayer ();
	}

	void movePlayer()
	{
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Jump");
		if (grounded){
			if (y > 0) {
				rb.velocity = new Vector2 (rb.velocity.x, y * jumpSpeed);
			}
		}
		if (x < 0 && canMoveLeft)
			rb.velocity = new Vector2 (x * moveSpeed, rb.velocity.y);
		else if(x > 0 && canMoveRight)
			rb.velocity = new Vector2 (x * moveSpeed, rb.velocity.y);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Ground") {
			grounded = true;
		}
		if (other.tag == "Wall") {
			if (rb.position.x > other.GetComponent<Transform> ().position.x) {
				canMoveLeft = false;
			}
			else if (rb.position.x < other.GetComponent<Transform> ().position.x) {
				canMoveRight = false;
			}
		}
		if (other.tag == "Button") {
			other.GetComponent<OpenDoor> ().OpenGreenDoor ();
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Ground") {
			grounded = false;
		}
		else if (other.tag == "Wall") {
			if (rb.position.x > other.GetComponent<Transform> ().position.x) {
				canMoveLeft = true;
			}
			else if (rb.position.x < other.GetComponent<Transform> ().position.x) {
				canMoveRight = true;
			}
		}
	}
}
