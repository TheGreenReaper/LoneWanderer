using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFind;

public class GridController : MonoBehaviour {
    public int width;
    public int height;
    GameObject[] canWalk;
    GameObject[] cannotWalk;

    void Start () {
        GetGrid();
    }

    public PathFind.Grid GetGrid()
    {
        bool[,] tilesmap = new bool[width, height];
        canWalk = GameObject.FindGameObjectsWithTag("canWalk");
        cannotWalk = GameObject.FindGameObjectsWithTag("cannotWalk");
        foreach (GameObject tile in canWalk){
            tilesmap[Mathf.RoundToInt(tile.transform.position.x), Mathf.RoundToInt(tile.transform.position.y)] = true;
        }
        foreach (GameObject tile in cannotWalk){
            tilesmap[Mathf.RoundToInt(tile.transform.position.x), Mathf.RoundToInt(tile.transform.position.y)] = false;
        }
        PathFind.Grid grid = new PathFind.Grid(width, height, tilesmap);
        return grid;
    }

}
