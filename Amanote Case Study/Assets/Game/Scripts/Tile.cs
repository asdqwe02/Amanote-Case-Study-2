using DG.Tweening;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileConfig tileConfig;
    protected float tapLineTime;
    protected float spawnTime;

    private float _moveTimeDebug;
    private void Awake()
    {

    }
    private void Start()
    {

    }
    public void SetUp(Vector3 startPos, Vector3 endPos)
    {
        // Note: this is not efficient should cache the screen bottom position when game start
        var bottomMiddle = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0f));
        transform.position = startPos;
        spawnTime = Time.time;

        // magic number 0.8, this do not scale with screen indicator need to refactor later
        tapLineTime = Mathf.Abs(endPos.y - transform.position.y) / tileConfig.speed * 0.8f;
        Move(endPos.y);

    }
    protected TileTapStatus CheckTileTapStatus()
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
        return tapStatus;
    }
    protected virtual void Move(float yPos)
    {
    }
    protected virtual void TileTap()
    {

    }
    protected virtual void OnMouseDown()
    {
        TileTap();
    }
    protected virtual void OnMouseOver()
    {

    }
    protected virtual void OnMouseUp()
    {

    }

}