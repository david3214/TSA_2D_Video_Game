﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour {
	public int heartNum;
	public float halfHeartNum;
	public bool empty;
	public bool halfFull;

	public Sprite FullHeart;
	public Sprite HalfHeart;
	// Use this for initialization
	void Start () {
		heartNum = int.Parse (name);
		halfHeartNum = heartNum - .5f;
		empty = false;
		halfFull = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (HealthNAttack.playerHealth < heartNum) {
			if (!halfFull && HealthNAttack.playerHealth == halfHeartNum) {
				halfFull = true;

				GetComponent<SpriteRenderer> ().sprite = HalfHeart;
			}
			else if(HealthNAttack.playerHealth < halfHeartNum && !empty){
				Destroy (this.gameObject);
			}
		}
	}
}
