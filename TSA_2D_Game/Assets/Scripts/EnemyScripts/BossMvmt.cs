using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMvmt : MonoBehaviour {
	public bool CanAttack = true;
	public bool idle = false;
	public int attackNumber;
	public float idleTime = .05f;
	public Vector3 StartingPos;
	public Vector3 Atk1Pos1 = new Vector3(16, 0, -1);
	public Vector3 Atk1Pos2 = new Vector3(-16, 0, -1);
	public Vector3 Atk2Pos = new Vector3 (0, 5, -1);
	public Vector3 Atk3Pos1 = new Vector3(16, -11, -1);
	public Vector3 Atk3Pos2 = new Vector3(-16, -11, -1);
	public SpriteRenderer sp;
	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer> ();
		StartingPos = transform.localPosition;
		attackNumber = 1;
		StartCoroutine (Idle ());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (CanAttack && !idle) {
			if (attackNumber == 1) {
				StartCoroutine (Attack1 ());
			} else if (attackNumber == 2) {
				StartCoroutine (Attack2 ());
			} else if (attackNumber == 3) {
				StartCoroutine (Attack3 ());
			}
		}
	}

	IEnumerator Attack1(){
		CanAttack = false;
		sp.enabled = false;
		Debug.Log ("Attack 1");
		yield return new WaitForSeconds(.5f);
		if (Random.Range (1, 3) == 1) {
			transform.localPosition = Atk1Pos1;
		} else {
			transform.localPosition = Atk1Pos2;
		}

		sp.enabled = true;

		yield return new WaitForSeconds (3.0f);

		attackNumber++;
		CanAttack = true;


	}
	IEnumerator Attack2(){
		
		CanAttack = false;
		sp.enabled = false;
		Debug.Log ("Attack 2");
		yield return new WaitForSeconds(.5f);

		transform.localPosition = Atk2Pos;

		sp.enabled = true;

		StartCoroutine (Idle());

		attackNumber++;
		CanAttack = true;

	}
	IEnumerator Attack3(){
		CanAttack = false;
		sp.enabled = false;
		Debug.Log ("Attack 3");
		yield return new WaitForSeconds(.5f);
		if (Random.Range (1, 3) == 1) {
			transform.localPosition = Atk3Pos1;// (16, 0, -1)
			sp.enabled = true;
			float i = 16;
			yield return new WaitForSeconds (1.0f);
			while (i > -16) {// (16, 0, -1) to (-16, 0, -1)
				transform.position = transform.position - new Vector3 (.1f, 0, 0);
				yield return new WaitForSeconds (.01f);
				i -= .1f;
			}
		} else {
			transform.localPosition = Atk3Pos2;
			sp.enabled = true;
			float i = -16;
			yield return new WaitForSeconds (1.0f);
			while (i < 16) {
				transform.position = transform.position + new Vector3 (.1f, 0, 0);
				yield return new WaitForSeconds (.01f);
				i += .1f;
			}
		}

		yield return new WaitForSeconds (3.0f);

		attackNumber = 1;
		CanAttack = true;
	}
	IEnumerator Idle(){
		idle = true;

		for (int j = 0; j < 2; j++) {
			float i = 0;
			while (i < 1f) {
				transform.position = transform.position + new Vector3 (0, .05f, 0);
				yield return new WaitForSeconds (idleTime);
				i += .1f;
			}
			i = 0;
			while (i < 2f) {
				transform.position = transform.position - new Vector3 (0, .05f, 0);
				yield return new WaitForSeconds (idleTime);
				i += .1f;
			}
			i = 0;
			while (i < 1f) {
				transform.position = transform.position + new Vector3 (0, .05f, 0);
				yield return new WaitForSeconds (idleTime);
				i += .1f;
			}
		}
		idle = false;

	}
}
