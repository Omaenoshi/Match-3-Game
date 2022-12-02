using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    public Row[] rows;

    public Tile[,] Tiles { get; private set; }

    public int Width => Tiles.GetLength(0);
    public int Height => Tiles.GetLength(1);
    private void Awake() => Instance = this;

    private void Start()
    {
        Tiles = new Tile[rows.Max(row => row.tiles.Length), rows.Length];

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var tile = rows[y].tiles[x];

                tile.x = x;
                tile.y = y;
                
                Tiles[x, y] = tile;

                tile.Item = ItemDB.Items[Random.Range(0, ItemDB.Items.Length)];
            }
        }
        
        
    }
}
