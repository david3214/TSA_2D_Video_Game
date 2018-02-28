using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour {
	public int heartNum;
	public bool empty;
	// Use this for initialization
	void Start () {
		heartNum = int.Parse (name);
		empty = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponentInParent<HealthNAttack> ().playerHealth < heartNum && !empty) {
			empty = true;
			GetComponent<SpriteRenderer> ().color = Color.gray;
		}
	}
}
