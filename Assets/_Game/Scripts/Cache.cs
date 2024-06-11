using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cache
{
    public static Dictionary<Collider2D, Tile> tiles = new Dictionary<Collider2D, Tile>();

    public static Tile GetTile(Collider2D col)
    {
        if (!tiles.ContainsKey(col))
        {
            tiles.Add(col, col.GetComponent<Tile>());
        }
        return tiles[col];
    }
}
