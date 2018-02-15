using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room1 : MonoBehaviour {



	// Use this for initialization
	public void LoadSceneAt(int level)
	{
		SceneManager.LoadScene(level);
	}
	
	// Update is called once per frame

}
