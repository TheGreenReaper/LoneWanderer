using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.childCount > 0)
        {
            gameObject.GetComponent<Image>().color = new Color(0, 1, 0, 0.5f);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

    }
}
