using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCore : MonoBehaviour {
	public int health = 100;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void TakeDamage(int damage){
		health -= damage;
		if(health < 1)
			Die();
	}
	void Die(){
		Destroy(gameObject);
	}
}
