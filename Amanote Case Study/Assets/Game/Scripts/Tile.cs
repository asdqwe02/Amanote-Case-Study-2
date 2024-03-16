using System;
using DG.Tweening;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private TileConfig _tileConfig;

    private float _spawnTime;
    private float _tapLineTime;
    private float _moveTimeDebug;
    private void Awake()
    {

    }
    private void Start()
    {

    }
    public void SetUp(Vector3 startPos, Vector3 endPos)
    {
        transform.position = startPos;
        _spawnTime = Time.time;
        _tapLineTime = Mathf.Abs(endPos.y - transform.position.y) / _tileConfig.speed * 0.6f;
        Move(endPos.y);

    }
    public void Move(float yPos)
    {
        var distance = Mathf.Abs(yPos - transform.position.y);
        // Debug
        _moveTimeDebug = distance / _tileConfig.speed;
        //
        transform
            .DOMoveY(yPos, distance / _tileConfig.speed)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                Destroy(gameObject);
            });
    }
    private void OnMouseDown()
    {
        var tapTime = Time.time - _spawnTime;
        var tapStatus = TileTapStatus.Good;
        if (tapTime <= _tapLineTime + _tileConfig.greatTimeThreshold
         && tapTime >= _tapLineTime - _tileConfig.greatTimeThreshold)
        {
            // Debug.Log($"tap great status! {tapTime} | upper: {_tapLineTime + _tileConfig.greatTimeThreshold} | lower: {_tapLineTime + _tileConfig.greatTimeThreshold}");
            tapStatus = TileTapStatus.Great;
        }
        if (tapTime <= _tapLineTime + _tileConfig.perfectTimeThreshold
        && tapTime >= _tapLineTime - _tileConfig.perfectTimeThreshold)
        {
            tapStatus = TileTapStatus.Perfect;
        }
        SystemSignal.TileTap(tapStatus);
        Destroy(gameObject);
    }
    private void OnMouseOver()
    {

    }
    private void OnMouseUp()
    {

    }

}