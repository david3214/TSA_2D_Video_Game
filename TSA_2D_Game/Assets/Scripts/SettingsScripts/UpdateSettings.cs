using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSettings : MonoBehaviour {

	public Slider VolumeSlider;

	// Use this for initialization
	void Start () {
		float PreviousValue = PlayerPrefs.GetFloat ("Volume");
		VolumeSlider.value = PreviousValue;
		string ValueString = Convert.ToString (PreviousValue);
		Debug.Log (ValueString);
	}
	
	// Update is called once per frame
	void Update () {
		float VolumeLevel = VolumeSlider.value;
		PlayerPrefs.SetFloat ("Volume", VolumeLevel);
	}
}
