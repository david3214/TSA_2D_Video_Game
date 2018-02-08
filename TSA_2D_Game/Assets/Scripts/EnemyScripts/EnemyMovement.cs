using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public float movementSpeed = 5.0f;
	public Vector2 moveLeft;
	public Vector2 moveRight;
	public Vector2 movingVec;
	public bool canSeePlayer = false;
	public Rigidbody2D rb;
	public int moveDelay = 1;
	public Transform trans;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		trans = GetComponent<Transform> ();

		moveLeft = new Vector2 (-1 * movementSpeed, rb.gravityScale * -1);
		moveRight = new Vector2(1 * movementSpeed, rb.gravityScale * -1);
		movingVec = moveRight;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		canSeePlayer = DetectPlayer ();
		if (canSeePlayer) {
			Debug.Log ("Detected");
			MonsterMovement ();
		} else if (moveDelay == 50) {
			MonsterMovement ();
			moveDelay = 1;
		} else {
			moveDelay++;
		}
	}

	void MonsterMovement(){
		if (canSeePlayer) {
			//If the player is in line of sight direction should have been changed accordingly, so move the monster in the direction of the player
			rb.velocity = movingVec;
		} else {
			int determineWalk = Random.Range (0, 5);
			if (determineWalk == 1) {
				//The Monster will move right
				if (movingVec == moveLeft) {
					//The monster is facing the other direction, and it needs to switch the direction its facing and move
					movingVec = moveRight;
					rb.velocity = movingVec;
				} else {
					rb.velocity = movingVec;
					//The monster is facing the right direction, so move it;
				}
			} else if (determineWalk == 2) {
				//The monster will move left
				if (movingVec == moveRight) {
					//The monster is facing the other direction, and it needs to switch the direction its facing and move
					movingVec = moveLeft;
					rb.velocity = movingVec;
				} else {
					//The monster is facing the right direction, so move it;
					rb.velocity = movingVec;
				}
			} else {


				//The monster will stay put
				rb.velocity = new Vector2 (0, 0);
			}
		}
	}

	bool DetectPlayer(){
		
		RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(trans.position.x, trans.position.y), new Vector2(100, 0));


		RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(trans.position.x, trans.position.y), new Vector2(-100, 0));

		if (hitRight.collider.tag == "Player") {
			if (movingVec == moveLeft) {
				movingVec = moveRight;
				return true;
			} else {
				return true;
			}
		} else if (hitLeft.collider.tag == "Player") {
			if (movingVec == moveRight) {
				movingVec = moveLeft;
				return true;
			} else {
				return true;
			}
		} else {
			return false;
		}



	}
}
