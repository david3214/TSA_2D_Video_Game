using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBossMinions : MonoBehaviour {
	public GameObject FormEnemy;
	public GameObject Enemy;

	public Vector3 spawn1 = new Vector3 (22,0,-1);
	public Vector3 spawn2 = new Vector3 (-23,0,-1);
	public Vector3 spawn3 = new Vector3 (0,0,-1);
	public Vector3 spawn4 = new Vector3 (-11,6,-1);
	public Vector3 spawn5 = new Vector3 (11,6,-1);

	void Awake(){
	}
	void Update(){
	}
	public void CreateEnemies(){
		GameObject enemy1;
		GameObject enemy2;
		int takenPos = 0;
		switch (Random.Range(1,6)){
		case 1:
			enemy1 = Instantiate (FormEnemy, transform);
			enemy1.transform.localPosition = spawn1;
			StartCoroutine (FinishForming (spawn1));
			takenPos = 1;
			break;
		case 2:
			enemy1 = Instantiate (FormEnemy, transform);
			enemy1.transform.localPosition = spawn2;
			StartCoroutine (FinishForming (spawn2));
			takenPos = 2;
			break;
		case 3:
			enemy1 = Instantiate (FormEnemy, transform);
			enemy1.transform.localPosition = spawn3;
			StartCoroutine (FinishForming (spawn3));
			takenPos = 3;
			break;
		case 4: 
			enemy1 = Instantiate (FormEnemy, transform);
			enemy1.transform.localPosition = spawn4;
			StartCoroutine (FinishForming (spawn4));
			takenPos = 4;
			break;
		case 5:
			enemy1 = Instantiate (FormEnemy, transform);
			enemy1.transform.localPosition = spawn5;
			StartCoroutine (FinishForming (spawn5));
			takenPos = 5;
			break;
		default:
			break;
		}
		switch (Random.Range (1, 6)) {
		case 1:
			if (takenPos != 1) {
				enemy2 = Instantiate (FormEnemy, transform);
				enemy2.transform.localPosition = spawn1;
				StartCoroutine (FinishForming (spawn1));
			}
			break;
		case 2:
			if (takenPos != 2) {
				enemy2 = Instantiate (FormEnemy, transform);
				enemy2.transform.localPosition = spawn2;
				StartCoroutine (FinishForming (spawn2));
			}
			break;
		case 3:
			if (takenPos != 3) {
				enemy2 = Instantiate (FormEnemy, transform);
				enemy2.transform.localPosition = spawn3;
				StartCoroutine (FinishForming (spawn3));
			}
			break;
		case 4: 
			if (takenPos != 4){
				enemy2 = Instantiate (FormEnemy, transform);
				enemy2.transform.localPosition = spawn4;
				StartCoroutine (FinishForming (spawn4));
			}
			break;
		case 5:
			if (takenPos != 5) {
				enemy2 = Instantiate (FormEnemy, transform);
				enemy2.transform.localPosition = spawn5;
				StartCoroutine (FinishForming (spawn5));
			}
			break;
		default:
			break;
		}
	}
	IEnumerator FinishForming(Vector3 spawnPos){
		yield return new WaitForSeconds (3f);

		GameObject FinishEnemy = Instantiate (Enemy, transform);
		FinishEnemy.transform.localPosition = spawnPos;
	}
}
