﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScript : MonoBehaviour {

	public AudioSource AS;
	// Use this for initialization
	void Start () {
		AS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		AS.volume = PlayerPrefs.GetFloat ("Volume");
	}
}
