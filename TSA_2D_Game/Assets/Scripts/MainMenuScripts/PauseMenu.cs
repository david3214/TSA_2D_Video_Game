using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static bool isPaused = false;

	public GameObject SettingsMenuUI;

	public GameObject PauseMenuUI;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (isPaused) {
				UnPause ();
			} else {
				Pause ();
			}
		}
	}
	public void Pause(){
		PauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		isPaused = true;
	}
	public void UnPause(){
		PauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		isPaused = false;
	}
	public void ClickExit(){
		Application.Quit ();
	}
	public void ClickSettings(){
		PauseMenuUI.SetActive (false);
		SettingsMenuUI.SetActive (true);
	}
	public void ClickBack(){
		PauseMenuUI.SetActive (true);
		SettingsMenuUI.SetActive (false);
	}


}
