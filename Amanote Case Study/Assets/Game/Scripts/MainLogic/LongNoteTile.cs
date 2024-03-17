
using DG.Tweening;
using System.Collections;
using UnityEngine;

public class LongNoteTile : Tile
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private SpriteRenderer _effectRenderer;
    [SerializeField] private ParticleSystem _effectParticle;
    private bool _hold;
    private bool _clicked;
    private TileTapStatus _tapStatus;
    private void Awake()
    {

    }
    private void Start()
    {

    }

    protected override void Move(float yPos)
    {
        var bottomMiddle = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0f));
        var distance = Mathf.Abs(bottomMiddle.y - transform.position.y) + _renderer.size.y;
        // Debug
        //_moveTimeDebug = distance / _tileConfig.speed;
        //
        transform
            .DOMoveY(bottomMiddle.y - _renderer.size.y, distance / tileConfig.speed)
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
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                Vector2 collisionPoint = hit.point;
                var diffY = Mathf.Abs(collisionPoint.y - _effectRenderer.transform.position.y);
                var ogSize = _effectRenderer.size;
                ogSize.y = diffY;
                _effectRenderer.size = ogSize;
                _effectParticle.transform.localPosition += new Vector3(0f, diffY, 0f);
                _effectParticle.gameObject.SetActive(true);
            }
            _clicked = true;
            _hold = true;
            _tapStatus = CheckTileTapStatus();
            StartCoroutine(IScoreTick());

        }

    }
    private void LateUpdate()
    {
        if (_hold && _effectRenderer.size.y < _renderer.size.y)
        {
            var ogSize = _effectRenderer.size;
            ogSize.y += tileConfig.speed * Time.deltaTime;
            _effectRenderer.size = ogSize;
            _effectParticle.transform
                .DOLocalMoveY(_effectParticle.transform.localPosition.y + tileConfig.speed * Time.deltaTime, Time.deltaTime)
                .SetEase(Ease.Linear);

        }
    }
    private void OnMouseUp()
    {
        if (_hold)
        {
            //Debug.Log("tap long tile end");
            _hold = false;
            _renderer.color = new Color(1f, 1f, 1f, 0.65f);
            _effectParticle.gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }
    private IEnumerator IScoreTick()
    {
        while (_hold)
        {
            SystemSignal.TileTap(_tapStatus);
            yield return new WaitForSeconds(tileConfig.longTileScoreTickTime);
        }
    }
}
