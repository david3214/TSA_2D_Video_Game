using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.Translate (new Vector3 (1, 0,0)* 5 * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
