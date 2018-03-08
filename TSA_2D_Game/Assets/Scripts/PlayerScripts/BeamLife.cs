using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamLife : MonoBehaviour {
	public int damage = 1;

	void Awake(){
		
		Destroy (this.gameObject, .2f);

	}
}
