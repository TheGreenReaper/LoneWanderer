using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFind;

public class Player : MonoBehaviour {
    public float speed;
    public GameObject nextLocationSprite;

    private Vector2 nextPosition;
    private Vector2 currentPosition;
    private List<Point> path;
    private Point _to;
    private Point _from;
    private GameObject grid;

    // Use this for initialization
    void Start () {
        nextPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        grid = GameObject.FindGameObjectWithTag("Grid");
    }

    // Update is called once per frame
    void Update()
    {
        nextLocationSprite.transform.position = nextPosition;

        /*sets origin and destination*/
        if (Input.GetMouseButtonDown(1))
        {
            RefreshPath();
        }
        /*sets path using origin and destination*/

        /*makes movement to next position smooth*/
        currentPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        transform.position = Vector2.MoveTowards(currentPosition, nextPosition, speed);
        /*makes movement to next position smooth*/

        /*if player has reached the next not final position, change it*/
        if (path != null && currentPosition == nextPosition)
        {
            SetNextNode();
        }
        /*if player has reached the next not final position, change it*/

    }
    void RefreshPath()
    {
        int toX = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x); //mouse x location
        int toY = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y); //mouse y location
        _to = new Point(toX, toY);
        _from = new Point(Mathf.RoundToInt(gameObject.transform.position.x), Mathf.RoundToInt(gameObject.transform.position.y));
        path = Pathfinding.FindPath(grid.GetComponent<GridController>().GetGridDefault(), _from, _to);
    }

    void SetNextNode()
    {
        int length = 0;
        int x = Mathf.RoundToInt(gameObject.transform.position.x); //ignored
        int y = Mathf.RoundToInt(gameObject.transform.position.y); //ignored
        foreach (Point node in path)
        {
            length++;
            x = node.x;
            y = node.y;
        }
        if (length > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(path[0].x, path[0].y), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Unwalkable")
                {
                    Debug.Log("STOP!");
                    nextPosition = currentPosition;
                }

            }
            else
            {
                nextPosition = new Vector2(path[0].x, path[0].y);
                path.RemoveAt(0);
            }

        }
    }
}
