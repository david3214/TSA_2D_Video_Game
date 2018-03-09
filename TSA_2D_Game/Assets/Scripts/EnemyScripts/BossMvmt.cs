using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMvmt : MonoBehaviour {
	public bool CanAttack;
	public bool startIdle;
	public int attackNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
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
}
