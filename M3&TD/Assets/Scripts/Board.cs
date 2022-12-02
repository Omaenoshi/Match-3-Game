using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public sealed class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    public Row[] rows;

    public Tile[,] Tiles { get; private set; }

    public int Width => Tiles.GetLength(0);
    public int Height => Tiles.GetLength(1);

    private readonly List<Tile> _selection = new List<Tile>();

    private const float TweenDuration = 0.25f;
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

    public async void Select(Tile tile)
    {
        if(!_selection.Contains(tile)) _selection.Add(tile); 
        
        if (_selection.Count < 2) return;

        Debug.Log($"Selected tiles at ({_selection[0].x}, {_selection[0].y}) and ({_selection[1].x}, {_selection[1].y})");

        await Swap(_selection[0], _selection[1]);
        
        _selection.Clear();
    }

    private async Task Swap(Tile tileFrom, Tile tileTo)
    {
        var iconFrom = tileFrom.icon;
        var iconTo = tileTo.icon;

        var iconFromTransform = iconFrom.transform;
        var iconToTransform = iconTo.transform;

        var sequence = DOTween.Sequence();

        sequence.Join(iconFromTransform.DOMove(iconToTransform.position, TweenDuration))
            .Join(iconToTransform.DOMove(iconFromTransform.position, TweenDuration));

        await sequence.Play()
            .AsyncWaitForCompletion();

        Sprite sp1 = tileFrom.GetComponent<Image>().sprite;
        Sprite sp2 = tileTo.GetComponent<Image>().sprite;

        tileFrom.GetComponent<Image>().sprite = sp2;
        tileTo.GetComponent<Image>().sprite = sp1;

        (tileFrom.Item, tileTo.Item) = (tileTo.Item, tileFrom.Item);
    }
}
