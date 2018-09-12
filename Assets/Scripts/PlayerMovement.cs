using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFind;

public class PlayerMovement : MonoBehaviour {
    public float speed;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StopAllCoroutines();
            GameObject tile;
            Point _to;
            Point _from;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                tile = hit.collider.gameObject;
                if (tile.tag == "canWalk")
                {
                    _to = new Point(Mathf.RoundToInt(tile.transform.position.x), Mathf.RoundToInt(tile.transform.position.y));
                    _from = new Point(Mathf.RoundToInt(gameObject.transform.position.x), Mathf.RoundToInt(gameObject.transform.position.y));
                    List<Point> path = Pathfinding.FindPath(gameObject.GetComponent<GridController>().GetGrid(), _from, _to);
                    StartCoroutine(MoveUser(path));
                }
            }
        }
    }
    IEnumerator MoveUser(List<Point> path)
    { 
        foreach (Point point in path)
        {
            transform.position = new Vector2(point.x, point.y);
            yield return new WaitForSeconds(speed);
        }
    }
}
