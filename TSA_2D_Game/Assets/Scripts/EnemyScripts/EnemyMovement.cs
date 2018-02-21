using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public float movementSpeed = 5.0f;
	public Rigidbody2D rb;
	//public Transform trans;
	public int direction = 1;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		//trans = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		MonsterMovement ();
	}

	void MonsterMovement(){
		rb.velocity = new Vector2 (movementSpeed * direction, rb.velocity.y);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Wall") {
			direction = direction * -1;
		}
	}
}