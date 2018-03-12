using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOrWin : MonoBehaviour {

	public void LoseGame(GameObject LoseCanvas){
		LoseCanvas.SetActive (true);
		this.gameObject.SetActive (false);
	}

}
