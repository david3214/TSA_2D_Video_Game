using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScript : MonoBehaviour {

	public AudioSource AS;

	public AudioClip Dungeon;
	public AudioClip MainArea;
	public AudioClip BossFight;

	// Use this for initialization
	void Start () {
		AS = GetComponent<AudioSource> ();
		ToDungeon ();
	}
	
	// Update is called once per frame
	void Update () {
		AS.volume = PlayerPrefs.GetFloat ("Volume");
	}

	public void ToDungeon(){
		AS.clip = Dungeon;
		AS.Play ();
	}
	public void ToMain(){
		AS.clip = MainArea;
		AS.Play ();
	}
	public void ToBoss(){
		AS.clip = BossFight;
		AS.Play ();
	}


}
