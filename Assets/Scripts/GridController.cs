using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFind;
using UnityEngine.Tilemaps;


public class GridController : MonoBehaviour {
    public int width;
    public int height;
     GridLayout gridLayout;
    public Tilemap tile;
    Vector3Int cellPosition;

    public string[] cannotWalkTiles;


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
                cellPosition = gridLayout.LocalToCell(new Vector2(x, y));
                if (tile.GetSprite(cellPosition) != null)
                {
                    for (int z = 0; z < cannotWalkTiles.Length; z++)
                    {
                        Debug.Log(string.Equals(cannotWalkTiles,tile.GetSprite(cellPosition).name));
                        /*if (cannotWalkTiles[z].CompareTo(tile.GetSprite(cellPosition).name) == 1)
                        {
                            tilesmap[x, y] = false;
                            Debug.Log("False at:" + x + " " + y);
                        }
                        else
                        {
                            tilesmap[x, y] = true;
                        }*/
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
