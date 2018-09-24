using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {
	int lives;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Enemy"){
			lives--;
		}
		if(lives < -1){
			Debug.Log("Game Over!");
		}
	}
}
