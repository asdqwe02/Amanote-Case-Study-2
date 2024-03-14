using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LaneController : MonoBehaviour
{
    [SerializeField] private List<Transform> _lanesPositions;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private GameObject _notePrefab;
    [SerializeField] private float _noteSpeed;
    // Start is called before the first frame update
    void Start()
    {
        SystemSignal.tileClickEvent += OnTileClick;
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
            var distance = Mathf.Abs(_endPosition.position.y - spawnpos.y);
            var note = Instantiate(_notePrefab, spawnpos, Quaternion.identity);
            note.transform
                .DOMoveY(_endPosition.position.y, distance / _noteSpeed)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    Destroy(note);
                });
            yield return new WaitForSeconds(_spawnDelay);
        }
        yield return null;
    }
    private void OnTileClick(Tile tile)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
