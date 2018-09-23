using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFind;
using UnityEngine.Tilemaps;


public class GridController : MonoBehaviour {
    public int width;
    public int height;
    public Tilemap unwalkable;
    Vector3Int cellPosition;
    GridLayout gridLayout;

    void Start ()
    {
        gridLayout = gameObject.GetComponent<GridLayout>();
    }
    public PathFind.Grid GetGridDefault()
    {
        bool[,] tilesmap = new bool[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tilesmap[x, y] = true;
                cellPosition = gridLayout.WorldToCell(new Vector2(x, y)); //finds position of a grid cell
                if (unwalkable.GetSprite(cellPosition) != null)
                {
                    tilesmap[x, y] = false;
                }
            }
        }
        PathFind.Grid grid = new PathFind.Grid(width, height, tilesmap);
        return grid;
    }
}
