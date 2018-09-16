using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFind;
using UnityEngine.Tilemaps;


public class GridController : MonoBehaviour {
    public int width;
    public int height;
    public Tilemap tileMap;
    public Sprite[] unwalkableSprites;

    Vector3Int cellPosition;
    GridLayout gridLayout;

    void Start ()
    {
        gridLayout = gameObject.GetComponent<GridLayout>();
    }
    public PathFind.Grid GetGrid()
    {
        bool[,] tilesmap = new bool[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                cellPosition = gridLayout.WorldToCell(new Vector2(x, y));
                if (tileMap.GetSprite(cellPosition) != null)
                {
                    for (int z = 0; z < unwalkableSprites.Length; z++)
                    {
                        if (unwalkableSprites[z].name.CompareTo(tileMap.GetSprite(cellPosition).name) == 1)
                        {
                            tilesmap[x, y] = true;
                        }
                        else
                        {
                            tilesmap[x, y] = false;
                        }
                    }
                }
                else
                {
                    tilesmap[x, y] = false;
                }
            }
        }
        PathFind.Grid grid = new PathFind.Grid(width, height, tilesmap);
        return grid;
    }
}
