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
	public bool canWallJump = true;
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
		rb.velocity = new Vector2 (x * moveSpeed, rb.velocity.y);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Ground") {
			grounded = true;
			canWallJump = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Ground") {
			grounded = false;
		}
		else if (other.tag == "Wall") {

		}
	}
	void OnTriggerStay2D(Collider2D other){
		float y = Input.GetAxis ("Jump");
		if (other.tag == "Wall" && !isJumping) {
			rb.velocity = new Vector2 (rb.velocity.x, slideSpeed);
		}
		if (y > 0 && canWallJump) {
			canWallJump = false;
			rb.velocity = new Vector2 (-jumpForce , jumpSpeed - slideSpeed);

		}
	}
}
