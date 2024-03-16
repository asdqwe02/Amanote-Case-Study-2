using DG.Tweening;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private TileConfig _tileConfig;
    private void Start()
    {

    }
    public void SetUp(Vector3 startPos, Vector3 endPos)
    {
        transform.position = startPos;
        Move(endPos.y);
    }
    public void Move(float yPos)
    {
        var distance = Mathf.Abs(yPos - transform.position.y);
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
        SystemSignal.TileTap();
        Destroy(gameObject);
    }
    private void OnMouseOver()
    {

    }

}