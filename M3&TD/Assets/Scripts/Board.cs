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

    [SerializeField] private ProgressBar _progressBar;

    [SerializeField] private float _count;

    public Tile[,] Tiles { get; private set; }

    public int Width => Tiles.GetLength(0);
    public int Height => Tiles.GetLength(1);

    private readonly List<Tile> _selection = new List<Tile>(2);

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
                do
                {
                    tile.Item = ItemDB.Items[Random.Range(0, ItemDB.Items.Length)];
                } while (tile.GetConnectedTiles().Count > 2);
            }
        }
    }
    
    private List<Tile> CheckComb(Tile tile)
    {
        int combX = 0;
        List<Tile> itemsX = new List<Tile>() {tile};
        for (int i = tile.x + 1; i < Tiles.GetLength(0); i++)
        {
            if (tile.Item.Equals(Tiles[i, tile.y].Item))
            {
                combX++;
                itemsX.Add(Tiles[i, tile.y]);
            }
            else
            {
                break;
            }
        }

        for (int i = tile.x - 1; i >= 0; i--)
        {
            if (tile.Item.Equals(Tiles[i, tile.y].Item))
            {
                combX++;
                itemsX.Add(Tiles[i, tile.y]);
            }
            else
            {
                break;
            }
        }

        int combY = 0;
        List<Tile> itemsY = new List<Tile>() {tile};
        
        for (int i = tile.y + 1; i < Tiles.GetLength(1); i++)
        {
            if (tile.Item.Equals(Tiles[tile.x, i].Item))
            {
                combY++;
                itemsY.Add(Tiles[tile.x, i]);
            }
            else
            {
                break;
            }
        }

        for (int i = tile.y - 1; i >= 0; i--)
        {
            if (tile.Item.Equals(Tiles[tile.x, i].Item))
            {
                combY++;
                itemsY.Add(Tiles[tile.x, i]);
            }
            else
            {
                break;
            }
        }

        if (combX >= 2 && combY < 2)
        {
            return itemsX;
        } 
        if (combY >= 2 && combX < 2)
        {
            return itemsY;
        }
        if (combX >= 2 && combY >= 2)
        {
            itemsY.Remove(tile);
            itemsX.AddRange(itemsY);
            return itemsX;
        }

        return null;
    }

    public async void Select(Tile tile)
    {
        if (_selection.Count == 0)
        {
            _selection.Add(tile);
        } else if (!_selection.Contains(tile) && _selection[0].Neighbours.Contains(tile))
        {
            _selection.Add(tile);
        }
        else
        {
            _selection.Clear();
        }
        
        if (_selection.Count < 2) return;

        Debug.Log($"Selected tiles at ({_selection[0].x}, {_selection[0].y}) and ({_selection[1].x}, {_selection[1].y})");

        await Swap(_selection[0], _selection[1]);
        

        if (CheckComb(_selection[1]) != null || CheckComb(_selection[0]) != null)
        {
            Pop();
        }
        else
        {
            await Swap(_selection[0], _selection[1]);
        }
        
        _selection.Clear();
    }

    private async Task Swap(Tile tile1, Tile tile2)
    {
        var icon1 = tile1.icon;
        var icon2 = tile2.icon;

        var icon1Transform = icon1.transform;
        var icon2Transform = icon2.transform;

        var sequence = DOTween.Sequence();

        sequence.Join(icon1Transform.DOMove(icon2Transform.position, TweenDuration))
            .Join(icon2Transform.DOMove(icon1Transform.position, TweenDuration));

        await sequence.Play().AsyncWaitForCompletion();

        icon1Transform.SetParent(tile2.transform);
        icon2Transform.SetParent(tile1.transform);

        tile1.icon = icon2;
        tile2.icon = icon1;

        (tile1.Item, tile2.Item) = (tile2.Item, tile1.Item);
    }

    private bool CheckPop()
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if (CheckComb(Tiles[x, y]) != null)
                    return true;
            }
        }

        return false;
    }

    private async void Pop()
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var tile = Tiles[x, y];

                var connectedTiles = CheckComb(tile);
                
                if (connectedTiles == null) continue;
                
                _progressBar.Fill(_count * connectedTiles.Count);

                var deflateSequence = DOTween.Sequence();

                foreach (var connectedTile in connectedTiles)
                {
                    deflateSequence.Join(connectedTile.icon.transform.DOScale(Vector3.zero, TweenDuration));
                    
                }

                await deflateSequence.Play().AsyncWaitForCompletion();

                var inflateSequence = DOTween.Sequence();

                foreach (var connectedTile in connectedTiles)
                {
                    connectedTile.Item = ItemDB.Items[Random.Range(0, ItemDB.Items.Length)];

                    inflateSequence.Join(connectedTile.icon.transform.DOScale(1f, TweenDuration));
                }

                await inflateSequence.Play().AsyncWaitForCompletion();
            }
        }

        if (CheckPop()) Pop();
    }

}
