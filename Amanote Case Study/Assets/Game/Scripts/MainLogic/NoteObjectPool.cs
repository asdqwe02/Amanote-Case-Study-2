using System;
using System.Collections.Generic;
using UnityEngine;

public class NoteObjectPool : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private List<Tile> _tiles;
    private void Awake()
    {
        SystemSignal.returnTileEvent += OnTileReturn;
        SystemSignal.getTileEvent += OnGetTile;
    }

    private void OnGetTile(Tile tile)
    {
        throw new NotImplementedException();
    }

    private void OnTileReturn()
    {
        throw new NotImplementedException();
    }

    public Tile Give()
    {
        return null;
    }
    public void Retrieved(Tile tile)
    {
        if (_tiles.Contains(tile))
        {
            tile.transform.position = transform.position;
            tile.gameObject.SetActive(false);
        }
    }
}