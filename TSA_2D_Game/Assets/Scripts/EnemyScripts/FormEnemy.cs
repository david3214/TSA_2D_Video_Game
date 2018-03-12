using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormEnemy : MonoBehaviour {
	public Sprite[] spriteSheet;
	public SpriteRenderer SR;
	// Use this for initialization
	void Start () {
		SR = GetComponent<SpriteRenderer> ();
		StartCoroutine (FormEnemyIE());
	}
	IEnumerator FormEnemyIE(){
		for (int i = 0; i < spriteSheet.Length; i++) {
			SR.sprite = spriteSheet [i];
			yield return new WaitForSeconds (1f);
		}
	}
}
