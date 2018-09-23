using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    GameObject player;
    public float speed;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y));
        if (distance > 4)
            speed = 3;
        else if(distance > 2)
            speed = 2;
        else
            speed = 0;

        if (speed > 0)
        {
            Vector3 currentPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
            Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            transform.position = Vector3.MoveTowards(currentPosition, playerPosition, speed * Time.deltaTime);
        }

    }
}
