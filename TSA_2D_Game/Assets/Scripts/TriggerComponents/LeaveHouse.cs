using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LeaveHouse : MonoBehaviour {

	public void LoadSceneAt(int level)
	{
		SceneManager.LoadScene(level);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			LoadSceneAt (1);
		}
	}
}
