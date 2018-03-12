using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMvmt : MonoBehaviour {
	public bool CanAttack = true;
	public bool idle = false;
	public int attackNumber;
	public float idleTime = .05f;

	public Vector3 StartingPos = new Vector3(0, 10, -1);
	public Vector3 Atk1Pos1 = new Vector3(22, 2, -1);
	public Vector3 Atk1Pos2 = new Vector3(-23, 2, -1);
	public Vector3 Atk2Pos = new Vector3 (0, 10, -1);
	public Vector3 Atk3Pos1 = new Vector3(22, -8, -1);
	public Vector3 Atk3Pos2 = new Vector3(-23, -8, -1);
	public float atk3Time = .01f;
	public SpriteRenderer sp;
	public BoxCollider2D BC;

	public float dmg = .5f;



	void Start () {
		sp = GetComponent<SpriteRenderer> ();
		BC = GetComponent<BoxCollider2D> ();
		attackNumber = 1;
		StartCoroutine (Idle (2f));
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
		BC.enabled = false;
		yield return new WaitForSeconds(.5f);
		if (Random.Range (1, 3) == 1) {
			transform.localPosition = Atk1Pos1;
		} else {
			transform.localPosition = Atk1Pos2;
		}

		BC.enabled = true;
		sp.enabled = true;

		yield return new WaitForSeconds (6.0f);

		attackNumber++;
		CanAttack = true;


	}
	IEnumerator Attack2(){
		
		CanAttack = false;
		sp.enabled = false;
		BC.enabled = false;
		yield return new WaitForSeconds(.5f);

		transform.localPosition = Atk2Pos;

		BC.enabled = true;
		sp.enabled = true;

		GetComponentInParent<CreateBossMinions> ().CreateEnemies ();

		StartCoroutine (Idle(4f));

		yield return new WaitForSeconds (12f);

		attackNumber++;
		CanAttack = true;

	}
	IEnumerator Attack3(){
		CanAttack = false;
		sp.enabled = false;
		BC.enabled = false;
		yield return new WaitForSeconds(.5f);
		if (Random.Range (1, 3) == 1) {
			transform.localPosition = Atk3Pos1;// (16, 0, -1)
			sp.enabled = true;
			BC.enabled = true;
			float i = 22;
			yield return new WaitForSeconds (1.0f);
			while (i > -23) {// (16, 0, -1) to (-23, 0, -1)
				transform.position = transform.position - new Vector3 (.5f, 0, 0);
				yield return new WaitForSeconds (atk3Time);
				i -= .5f;
			}
		} else {
			transform.localPosition = Atk3Pos2;
			sp.enabled = true;
			BC.enabled = true;
			float i = -23;
			yield return new WaitForSeconds (1.0f);
			while (i < 22) {
				transform.position = transform.position + new Vector3 (.5f, 0, 0);
				yield return new WaitForSeconds (atk3Time);
				i += .5f;
			}
		}

		yield return new WaitForSeconds (3.0f);

		attackNumber = 1;
		CanAttack = true;
	}
	IEnumerator Idle(float num){
		idle = true;

		for (int j = 0; j < num; j++) {
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
