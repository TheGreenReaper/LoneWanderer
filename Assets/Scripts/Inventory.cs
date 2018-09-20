using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    GameObject[] inventorySlots;
	// Use this for initialization
	void Start () {
        inventorySlots = GameObject.FindGameObjectsWithTag("InventorySlot");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
