using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFind;
using UnityEngine.Tilemaps;


public class GridController : MonoBehaviour {
    public int width;
    public int height;
    public Tilemap unwalkable;
    public Tilemap unwalkable2;
    //public Sprite[] unwalkableSprites;

    Vector3Int cellPosition;
    GridLayout gridLayout;

    void Start ()
    {
        gridLayout = gameObject.GetComponent<GridLayout>();
    }
    public PathFind.Grid GetGrid(int npcX, int npcY)
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

                RaycastHit2D hit = Physics2D.Raycast(new Vector2(x,y), Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Unwalkable")
                    {
                        tilesmap[x, y] = false;
                    }
                }

                if (npcX == x && npcY == y)
                {
                    tilesmap[x, y] = true;
                }
            }
        }

        PathFind.Grid grid = new PathFind.Grid(width, height, tilesmap);
        return grid;
    }
}
