﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody2D rb;
	public float moveSpeed = 7.0f;
	public float jumpSpeed = 7.5f;

	public bool grounded = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
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
		} else if (other.tag == "Wall") {

		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Ground") {
			grounded = false;
		}
		else if (other.tag == "Wall") {

		}
	}
}
