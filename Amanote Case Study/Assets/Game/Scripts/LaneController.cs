using System;
using System.Collections.Generic;
using UnityEngine;

public class LaneController : MonoBehaviour
{
    [SerializeField] private List<Transform> _lanesPositions;
    // Start is called before the first frame update
    void Start()
    {
        SystemSignal.tileClickEvent += OnTileClick();
    }

    private Action<Tile> OnTileClick()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
