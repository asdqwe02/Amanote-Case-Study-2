using DG.Tweening;
using UnityEngine;

public class NoteTile : Tile
{
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
        SystemSignal.TileTap(CheckTileTapStatus());
        // Play effect then destroy
        Destroy(gameObject);
    }
}
