using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalHealth : MonoBehaviour {

	public int bossHealth = 10;

	public bool BeginingIdle;

	public Vector3 Pos1 = new Vector3 (0, 2.5f, -1);
	public Vector3 Pos2 = new Vector3 (-23, 2.5f, -1);
	public Vector3 Pos3 = new Vector3 (22, 2.5f, -1);
	public Vector3 Pos4 = new Vector3 (-11, 9, -1);
	public Vector3 Pos5 = new Vector3 (11, 9, -1);

	public GameObject currentObj;
	public GameObject winObj;
	// Use this for initialization
	void Awake () {
		StartCoroutine(beginingIdle());
	}

	void Update(){
		if (Random.Range (0, 250) == 100) {
			switch (Random.Range (1, 6)) {
			case 1:
				transform.localPosition = Pos1;
				break;
			case 2:
				transform.localPosition = Pos2;
				break;
			case 3:
				transform.localPosition = Pos3;
				break;
			case 4:
				transform.localPosition = Pos4;
				break;
			case 5:
				transform.localPosition = Pos5;
				break;
			default:
				break;
			}
		}
	}

	IEnumerator beginingIdle(){
		BeginingIdle = true;
		yield return new WaitForSeconds (3f);
		BeginingIdle = false;
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Weapon") {
			Debug.Log ("Weapon");
			bossHealth = bossHealth - 1;
			if (bossHealth <= 0) {
				WinGame ();
			} else {
				switch (Random.Range (1, 6)) {
				case 1:
					transform.localPosition = Pos1;
					break;
				case 2:
					transform.localPosition = Pos2;
					break;
				case 3:
					transform.localPosition = Pos3;
					break;
				case 4:
					transform.localPosition = Pos4;
					break;
				case 5:
					transform.localPosition = Pos5;
					break;
				default:
					break;
				}
			}
		}
		if (other.tag == "Player") {
			Debug.Log ("Player");
		}

	}
	void WinGame(){
		currentObj.SetActive (false);
		winObj.SetActive (true);
	}

}
