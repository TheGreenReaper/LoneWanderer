using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour {

    public void UseAndDestroy()
    {
        GameObject.Find("PlayerHP").GetComponent<Image>().fillAmount += 0.2f;
        Debug.Log("Item Used and Destroyed");
        Destroy(gameObject);
    }
    
}

