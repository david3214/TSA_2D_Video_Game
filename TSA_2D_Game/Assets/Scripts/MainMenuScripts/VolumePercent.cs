using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumePercent : MonoBehaviour {


	public Text text;

	// Use this for initialization
	void Start () {
		float PreviousValue = PlayerPrefs.GetFloat ("Volume");
		int previousVal = (int)(PreviousValue * 100f);
		text.text = " " + Convert.ToString (previousVal) + "%";
	}

	// Update is called once per frame
	void Update () {
		float PreviousValue = PlayerPrefs.GetFloat ("Volume");
		int previousVal = (int)(PreviousValue * 100f);
		text.text = " " + Convert.ToString (previousVal) + "%";
	}
}
