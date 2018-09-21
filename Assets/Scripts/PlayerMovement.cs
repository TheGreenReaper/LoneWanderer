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
    private int npcLocationX;
    private int npcLocationY;
    private int width;
    private int height;
    private GameObject grid;
    public GameObject nextLocationSprite;
    void Start()
    {
        nextPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        grid = GameObject.FindGameObjectWithTag("Grid");
        width = grid.GetComponent<GridController>().width;
        height = grid.GetComponent<GridController>().height;
    }
    void Update()
    {
        nextLocationSprite.transform.position = nextPosition;
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

        int toX = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x); //mouse x location
        int toY = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y); //mouse y location


        /*checks if the target tile is unwalkable*/
        npcLocationX = -1;
        npcLocationY = -1;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Unwalkable")
            {
                npcLocationX = Mathf.RoundToInt(hit.collider.transform.position.x);
                npcLocationY = Mathf.RoundToInt(hit.collider.transform.position.y);
            }
        }
        /*checks if the target tile is unwalkable*/



        if (toX > -1 && toY > -1 && toX <= width && toY <= height)
        {
            if (width < toX)
                toX = width;
            if (height < toY)
                toY = height;
            _to = new Point(toX, toY);
            _from = new Point(Mathf.RoundToInt(gameObject.transform.position.x), Mathf.RoundToInt(gameObject.transform.position.y));
            path = Pathfinding.FindPath(grid.GetComponent<GridController>().GetGrid(npcLocationX, npcLocationY), _from, _to);
        }


        /*removes last location is its unwalkable*/
        if (npcLocationX != -1 && npcLocationY != -1 && path != null)
        {
            int length = -1;
            foreach (Point node in path)
            {
                length++;
            }
            if (length > -1)
            {
                path.RemoveAt(length);
            }
        }
        /*removes last location is its unwalkable*/

    }
    void SetNextNode()
    {
        if (path != null)
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
    }
