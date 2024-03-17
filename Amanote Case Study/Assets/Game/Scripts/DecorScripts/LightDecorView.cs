using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LightDecorView : MonoBehaviour
{
    [SerializeField] private Image _decorImage;
    [Header("Decor Effet Config")]
    [SerializeField] private float _effectTime;
    private Tweener _effectTweener;
    private void Awake()
    {
        SystemSignal.tileTapEvent += OnTileTapEvent;
    }

    private void OnTileTapEvent(TileTapStatus status)
    {
        _decorImage.DOKill(); 
        _decorImage.color = new Color(1f, 1f, 1f, 0.5f);
        _effectTweener = _decorImage.DOColor(Color.white, _effectTime).SetEase(Ease.Linear).OnComplete(() =>
        {
            _decorImage.DOColor(new Color(1f, 1f, 1f, 0.5f), _effectTime).SetEase(Ease.OutBack);
        });
    }
}
