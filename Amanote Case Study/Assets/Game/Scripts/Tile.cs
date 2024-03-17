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
        tapLineTime = Mathf.Abs(endPos.y - transform.position.y) / tileConfig.speed * 0.6f;
        Move(endPos.y);

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