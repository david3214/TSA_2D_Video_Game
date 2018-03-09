using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMvmt : MonoBehaviour {
	public bool CanAttack;
	public bool idle = false;
	public int attackNumber;
	public float idleTime = .05f;
	// Use this for initialization
	void Start () {
		StartCoroutine (Idle ());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!idle) {
			
		}
	}

	IEnumerator Attack1(){
		yield return new WaitForSeconds(0);
	}
	IEnumerator Attack2(){
		yield return new WaitForSeconds(0);
	}
	IEnumerator Attack3(){
		yield return new WaitForSeconds(0);
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
