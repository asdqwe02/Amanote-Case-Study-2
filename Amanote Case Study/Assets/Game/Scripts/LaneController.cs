using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneController : MonoBehaviour
{
    [SerializeField] private List<Transform> _lanesPositions;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private Transform _tapLine;
    [SerializeField] private TileConfig _tileConfig;
    [SerializeField] private Tile _noteTilePrefab;
    [SerializeField] private Tile _longNoteTilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNotes();
    }
    private void SpawnNotes()
    {
        StartCoroutine(ISpawnNote());
    }
    private IEnumerator ISpawnNote()
    {
        var laneIndex = -1;
        while (true)
        {
            laneIndex++;
            if (laneIndex >= _lanesPositions.Count)
            {
                laneIndex = 0;
            }
            var spawnpos = _lanesPositions[laneIndex].position;
            spawnpos.z = 0;
            var note = Instantiate(_longNoteTilePrefab, spawnpos, Quaternion.identity);
            note.SetUp(spawnpos, _endPosition.position);
            yield return new WaitForSeconds(_tileConfig.normalTileSpawnDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
