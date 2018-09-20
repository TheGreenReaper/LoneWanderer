using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battleground : MonoBehaviour {
    public GameObject player;
    public GameObject enemy;
    public bool playerTurn = true;
    // Use this for initialization

    public void ChangeTurn()
    {
        playerTurn = !playerTurn;
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        foreach (GameObject button in buttons)
        {
            button.GetComponent<Button>().interactable = playerTurn;
        }
        if(playerTurn == false)
            enemy.GetComponent<EnemyScript>().MakeMove();

        if (playerTurn)
            Debug.Log("Player Turn");
        else
            Debug.Log("eNEMY Turn");
    }


}
