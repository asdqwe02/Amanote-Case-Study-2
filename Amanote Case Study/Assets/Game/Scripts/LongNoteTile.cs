
using DG.Tweening;
using UnityEngine;

public class LongNoteTile : Tile
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private SpriteRenderer _effectRenderer;
    private bool _hold;
    private bool _clicked;
    private void Awake()
    {

    }
    private void Start()
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
        if (!_clicked)
        {
            // Get the mouse position in world space
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Perform a raycast to check for collisions
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // If a collision is detected, get the collision point
            if (hit.collider != null)
            {
                Vector2 collisionPoint = hit.point;
                //Debug.Log("Collision Position: " + collisionPoint);

                var diffY = Mathf.Abs(collisionPoint.y - _effectRenderer.transform.position.y);
                var ogSize = _effectRenderer.size;
                ogSize.y = diffY;
                _effectRenderer.size = ogSize;
            }
            _clicked = true;
            _hold = true;
        }

    }
    private void LateUpdate()
    {
        if (_hold && _effectRenderer.size.y < _renderer.size.y)
        {
            var ogSize = _effectRenderer.size;
            ogSize.y += tileConfig.speed * Time.deltaTime;
            _effectRenderer.size = ogSize;
        }
    }
    private void OnMouseUp()
    {
        if (_hold)
        {
            //Debug.Log("tap long tile end");
            _hold = false;
            _renderer.color = new Color(1f, 1f, 1f, 0.65f);
        }
    }
}
