using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveManager : MonoBehaviour
{
    public static MoveManager instance;

    void awake()
    {
        instance = this;
    }
    public void SetAreaTiles(Vector2 pos, int movement, Color color)
    {
        Dictionary<Vector2, Tile> tiles = GridManager.instance._tiles;
        List<Tile> area = tiles.Where(t => (Mathf.Abs(t.Key.x - pos.x) < movement && Mathf.Abs(t.Key.y - pos.y) < movement)).ToDictionary(t => t.Key, t => t.Value).Values.ToList();
        foreach (Tile tile in area)
        {
            tile.inRange = true;
            tile.rangeHighlight.SetActive(true);
            tile.rangeHighlight.GetComponent<SpriteRenderer>().color = color;
        }
    }
    public void SetMovementTiles(Vector2 pos, int movement, Color color)
    { //selects tiles in range
        Dictionary<Vector2, Tile> tiles = GridManager.instance._tiles;
        int moveCount = 0;
        List<Tile> area = new List<Tile>();
        area.Add(GridManager.instance.GetTileAtPosition(pos));

        while (moveCount < movement) 
        {
            foreach (Tile tile in area.ToList())
            {//uses BFS aka breadth first search
                Vector2 TilePos = tile.transform.position;
                if (Tile.Walkable == true || TilePos == pos && Tile.ischeck = false)
                {
                    if (GridManager.instance.GetTileAtPosition(new Vector2(TilePos.x + 1, TilePos.y)) !=null && GridManager.instance.GetTileAtPosition(new Vector2(TilePos.x + 1, TilePos.y)).ischeck == false)
                    {
                        var nextTile = GridManager.instance.GetTileAtPosition(new Vector2(TilePos.x + 1, TilePos.y));
                        area.Add(nextTile);
                        nextTile.parent = tile;
                        if (nextTile.dist == -1) nextTile.dist = moveCount + 1;
                    }
                    if (GridManager.instance.GetTileAtPosition(new Vector2(TilePos.x - 1, TilePos.y)) != null && GridManager.instance.GetTileAtPosition(new Vector2(TilePos.x - 1, TilePos.y)).ischeck == false)
                    {
                        var nextTile = GridManager.instance.GetTileAtPosition(new Vector2(TilePos.x - 1, TilePos.y));
                        area.Add(nextTile);
                        nextTile.parent = tile;
                        if (nextTile.dist == -1) nextTile.dist = moveCount + 1;
                    }
                    if (GridManager.instance.GetTileAtPosition(new Vector2(TilePos.x, TilePos.y + 1)) != null && GridManager.instance.GetTileAtPosition(new Vector2(TilePos.x, TilePos.y + 1)).ischeck == false)
                    {
                        var nextTile = GridManager.instance.GetTileAtPosition(new Vector2(TilePos.x, TilePos.y + 1));
                        area.Add(nextTile);
                        nextTile.parent = tile;
                        if (nextTile.dist == -1) nextTile.dist = moveCount + 1;
                    }
                    if (GridManager.instance.GetTileAtPosition(new Vector2(TilePos.x + 1, TilePos.y - 1)) != null && GridManager.instance.GetTileAtPosition(new Vector2(TilePos.x + 1, TilePos.y - 1)).ischeck == false)
                    {
                        var nextTile = GridManager.instance.GetTileAtPosition(new Vector2(TilePos.x + 1, TilePos.y - 1));
                        area.Add(nextTile);
                        nextTile.parent = tile;
                        if (nextTile.dist == -1) nextTile.dist = moveCount + 1;
                    }
                    tile.ischeck = true;
            }

          
            
        }
    }
        moveCount++;
        {// allows tiles inRange to be true
            foreach (Tile tile in area.ToList())
            {
                if (Tile.Walkable == true)
                {
                    tile.inRange = true;
                    tile.rangeHighlight.SetActive(true);
                    tile.rangeHighlight.GetComponent<SpriteRenderer>().color = color;

                    tile.ischeck = true;
                }
            }
        }
        //public void CleanMovementTiles()
        {
            Dictionary<Vector2, Tile> _tiles = GridManager.instance._tiles;

            foreach(Tile tile in tiles.Values)
            {
                tile.inRange = false;
                tile.rangeHighlight.SetActive(false);

                tile.ischeck = false;
                tile.parent = tile;
                tile.dist = -1;
            }
        }
        //public bool CheckRangeTiles()
        {
            Dictionary<Vector2, Tile> _tiles = GridManager.instance._tiles;
            foreach(Tile tile in tiles.Values)
            {
                if (tile.inRange == true)
                {
                    if (tile.OccupiedUnit != null && tile.OccupiedUnit.Faction == Faction.Faction2)
                    {
                        return true;
                    }
                }
            }
        }
}

