using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        PlayerPrefs.SetInt("Health", 100);
        PlayerPrefs.SetInt("Damage", 20);
        PlayerPrefs.SetInt("ActionPoints", 100);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
