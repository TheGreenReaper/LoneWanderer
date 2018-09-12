    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using PathFind;

    public class PlayerMovement : MonoBehaviour {
    public float speed;
    private Vector2 nextPosition;
    private Vector2 currentPosition;
    private List<Point> path;
    private GameObject tile;
    private Point _to;
    private Point _from;

    private void Start()
    {
        nextPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    void Update()
    {
        
        currentPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (Input.GetMouseButtonDown(1))
        {
            FindPath();
        }
        if (currentPosition != nextPosition)
        {
            transform.position = Vector2.Lerp(currentPosition, nextPosition, speed);
        }
        if (path != null && currentPosition == nextPosition)
        {
            SetNextNode();
        }
            
        //path.RemoveAt(0);
        //}
    }

    void FindPath()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            tile = hit.collider.gameObject;
            if (tile.tag == "canWalk")
            {
                _to = new Point(Mathf.RoundToInt(tile.transform.position.x), Mathf.RoundToInt(tile.transform.position.y));
                _from = new Point(Mathf.RoundToInt(gameObject.transform.position.x), Mathf.RoundToInt(gameObject.transform.position.y));
                path = Pathfinding.FindPath(gameObject.GetComponent<GridController>().GetGrid(), _from, _to);
            }
        }
    }
    void SetNextNode()
    {
        int length = 0;
        foreach (Point node in path)
        {
            length++;
        }
        if (length > 0)
        {
            nextPosition = new Vector2(path[0].x, path[0].y);
            path.RemoveAt(0);
            Debug.Log("Next Position: " + nextPosition + " Remaining: " + length);
        }
    }
    }
