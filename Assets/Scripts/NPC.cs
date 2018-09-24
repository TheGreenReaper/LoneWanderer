using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFind;

public class NPC : MonoBehaviour {
  public float speed;

  private GameObject targetDestination;
  private GameObject grid;
  private Vector2 nextPosition;
  private Vector2 currentPosition;
  private List<Point> path;
  private Point _to;
  private Point _from;

  // Use this for initialization
  void Start () {
    currentPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
      nextPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
      targetDestination = GameObject.Find("Goal");
      grid = GameObject.Find("Grid");
      SetDestination();
  }

  // Update is called once per frame
  void Update () {
      /*makes movement to next position smooth*/
      transform.position = Vector2.MoveTowards(currentPosition, nextPosition, speed);
      currentPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
      /*makes movement to next position smooth*/

      /*if targetDestination has reached the next not final position, change it*/
      if (path != null && currentPosition == nextPosition)
      {
          SetNextNode();
      }
      /*if targetDestination has reached the next not final position, change it*/

  }
  void SetDestination()
  {
      int toX = Mathf.RoundToInt(targetDestination.transform.position.x);
      int toY = Mathf.RoundToInt(targetDestination.transform.position.y);
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
              if (hit.collider.tag == "Block")
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
