﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArenaStuff : MonoBehaviour {
	public GameObject Boss;
	// Use this for initialization
	void Start () {
		
	}
	public void playerEnter(){
		Boss.SetActive (true);
	}

}
