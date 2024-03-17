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
            //laneIndex++;
            //if (laneIndex >= _lanesPositions.Count)
            //{
            //    laneIndex = 0;
            //}
            laneIndex = Random.Range(0, _lanesPositions.Count);
            var spawnpos = _lanesPositions[laneIndex].position;
            spawnpos.z = 0;

            var noteType = Random.Range(0f, 1f);
            if (noteType <= 0.75f)
            {
                var note = Instantiate(_noteTilePrefab, spawnpos, Quaternion.identity);
                note.SetUp(spawnpos, _endPosition.position);
                yield return new WaitForSeconds(_tileConfig.normalTileSpawnDelay);
            }
            else
            {
                var note = Instantiate(_longNoteTilePrefab, spawnpos, Quaternion.identity);
                note.SetUp(spawnpos, _endPosition.position);
                yield return new WaitForSeconds(_tileConfig.longNoteTileSpawnDelay);
            }

        }
    }
}
