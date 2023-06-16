using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
            
            tile.rangeHighlight.SetActive(true);
            tile.rangeHighlight.GetComponent<SpriteRenderer>().color = color;
        }
    }
    public void SetMovementTiles (Vector2 pos, int movement, Color color)
    {
        Dictionary<Vector2, Tile> tiles = GridManager.instance._tiles;
        int moveCount = 0;
        List<Tile> area = new List<Tile>();
        area.Add(GridManager.instance.GetTileAtPosition(pos));
        while (moveCount < movement) ;
    }
}
