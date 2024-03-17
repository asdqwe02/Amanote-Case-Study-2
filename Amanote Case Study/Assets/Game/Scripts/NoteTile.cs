using DG.Tweening;
using UnityEngine;

public class NoteTile : Tile
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Move(float yPos)
    {
        var bottomMiddle = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0f));
        var distance = Mathf.Abs(bottomMiddle.y - transform.position.y - tileConfig.tileLength);
        // Debug
        //_moveTimeDebug = distance / _tileConfig.speed;
        //
        transform
            .DOMoveY(bottomMiddle.y - tileConfig.tileLength, distance / tileConfig.speed)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                Destroy(gameObject);
            });
    }
    protected override void TileTap()
    {
        var tapTime = Time.time - spawnTime;
        var tapStatus = TileTapStatus.Good;
        if (tapTime <= tapLineTime + tileConfig.greatTimeThreshold
         && tapTime >= tapLineTime - tileConfig.greatTimeThreshold)
        {
            // Debug.Log($"tap great status! {tapTime} | upper: {_tapLineTime + _tileConfig.greatTimeThreshold} | lower: {_tapLineTime + _tileConfig.greatTimeThreshold}");
            tapStatus = TileTapStatus.Great;
        }
        if (tapTime <= tapLineTime + tileConfig.perfectTimeThreshold
        && tapTime >= tapLineTime - tileConfig.perfectTimeThreshold)
        {
            tapStatus = TileTapStatus.Perfect;
        }
        SystemSignal.TileTap(tapStatus);
        Destroy(gameObject);
    }
}
