using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFind;

public class EnemyMovement : MonoBehaviour {
    public float speed;
    public int detectRange;
    private Vector2 nextNode;
    private Vector2 enemyPosition;
    private Vector2 playerPosition;
    private List<Point> path;
    private Point _to;
    private Point _from;
    private GameObject player;
    private bool isChasing;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isChasing = false;
        nextNode = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }
    void Update()
    {
        FindPath();

        enemyPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);

        if (isChasing == true && enemyPosition != nextNode)
        {
            transform.position = Vector2.MoveTowards(enemyPosition, nextNode, 0.1f);
        }
        if (path != null && enemyPosition == nextNode)
        {
            SetNextNode();
        }
    }
    void FindPath()
    {
        int nodeOff;

        if (enemyPosition.x < playerPosition.x)
            nodeOff = 1;
        else
            nodeOff = -1;


        _to = new Point(Mathf.RoundToInt(playerPosition.x) + nodeOff, Mathf.RoundToInt(playerPosition.y));
        _from = new Point(Mathf.RoundToInt(enemyPosition.x), Mathf.RoundToInt(enemyPosition.y));
        GameObject grid = GameObject.FindGameObjectWithTag("Grid");
        path = Pathfinding.FindPath(grid.GetComponent<GridController>().GetGrid(), _from, _to);

        int length = 0;
        foreach (Point node in path)
        {
            length++;
        }
        if (length <= detectRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
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
            nextNode = new Vector2(path[0].x, path[0].y);
            path.RemoveAt(0);
        }
    }
}
