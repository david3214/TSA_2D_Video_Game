using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public float movementSpeed = 5.0f;
	public Rigidbody2D rb;
	//public Transform trans;
	public int direction = -1;
	public float velocityx;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		//trans = GetComponent<Transform> ();
		velocityx = rb.velocity.x;
		Flip ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		velocityx = rb.velocity.x;
		MonsterMovement ();

		if (Random.Range (0, 500) == 250) {
			direction = direction * -1;
			Flip ();
		}
	}

	void MonsterMovement(){
		rb.velocity = new Vector2 (movementSpeed * direction, rb.velocity.y);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Wall" || other.tag == "EWall" || other.tag == "Enemy") {
			direction = direction * -1;
			Flip ();
		}
		else if(other.tag == "Weapon"){
			Destroy (this.gameObject);
		}
	}
	/*void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Wall" || other.tag == "EWall" || other.tag == "Enemy") {
			direction = direction * -1;
			Flip ();
		}
		else if(other.tag == "Weapon"){
			Destroy (this.gameObject);
		}
	}*/
	void Flip(){
		if (direction > 0) {
			GetComponent<SpriteRenderer> ().flipX = false;
		} else {
			GetComponent<SpriteRenderer> ().flipX = true;
		}
	}
}