using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject[] enemies;
	public int speed;
	// Use this for initialization
	void Start () {
		Invoke("SpawnWave",1);
	}

	// Update is called once per frame
	void Update () {

	}
	void SpawnWave(){
		GameObject ammoInst = Instantiate(enemies[0],gameObject.transform.position,transform.rotation) as GameObject;
		Invoke("SpawnWave",speed);

	}
}
