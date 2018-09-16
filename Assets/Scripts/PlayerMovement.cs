    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using PathFind;

    public class PlayerMovement : MonoBehaviour {
    public float speed;
    private Vector2 nextPosition;
    private Vector2 currentPosition;
    private List<Point> path;
    private Point _to;
    private Point _from;

    void Start()
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
            transform.position = Vector2.MoveTowards(currentPosition, nextPosition, 0.1f);
        }
        if (path != null && currentPosition == nextPosition)
        {
            SetNextNode();
        }
    }
    void FindPath()
    {
        int toX = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        int toY = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        if (toX > -1 && toY > -1)
        {
            _to = new Point(toX, toY);
            _from = new Point(Mathf.RoundToInt(gameObject.transform.position.x), Mathf.RoundToInt(gameObject.transform.position.y));
            GameObject grid = GameObject.FindGameObjectWithTag("Grid");
            path = Pathfinding.FindPath(grid.GetComponent<GridController>().GetGrid(), _from, _to);
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
        }
    }
    }
