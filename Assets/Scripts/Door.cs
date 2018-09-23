﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void Start()
    {
    }
    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 currentPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        if (Vector2.Distance(playerPosition, currentPosition) < 2 && Input.GetKeyDown(KeyCode.F)){
            Destroy(gameObject);
        }
    }
}
