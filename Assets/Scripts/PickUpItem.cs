using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour {
    public GameObject item;

    private void Start()
    {
        Debug.Log(gameObject.tag);
    }
    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 currentPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Debug.Log(Vector2.Distance(playerPosition, currentPosition));
        if (Vector2.Distance(playerPosition, currentPosition) < 2 && Input.GetKeyDown(KeyCode.F))
        {
            GameObject[] inventorySlots = GameObject.FindGameObjectsWithTag("InventorySlot");
            foreach (GameObject slot in inventorySlots)
            {
                if (slot.transform.childCount == 0 && Input.GetKeyDown(KeyCode.F))
                {
                    Instantiate(item, slot.transform);
                    Destroy(gameObject);
                    break;
                }

            }
        }
    }
}
