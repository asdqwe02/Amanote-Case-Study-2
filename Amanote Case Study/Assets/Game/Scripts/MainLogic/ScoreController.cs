using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _tapStatusText;

    [Header("Config")]
    [SerializeField] private List<int> _tileTapScoreConfigs;



    private void Awake()
    {
        SystemSignal.tileTapEvent += OnTileTap;
        _scoreText.text = MainModel.score.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTileTap(TileTapStatus status)
    {
        switch (status)
        {
            case TileTapStatus.Good:
                MainModel.score += _tileTapScoreConfigs[0];
                break;
            case TileTapStatus.Great:
                MainModel.score += _tileTapScoreConfigs[1];
                break;
            case TileTapStatus.Perfect:
                MainModel.score += _tileTapScoreConfigs[2];
                break;
        }
        TapTextEffect(status);
        _scoreText.text = MainModel.score.ToString();
    }

    private void TapTextEffect(TileTapStatus tileTapStatus)
    {
        _tapStatusText.transform.DOKill();
        _scoreText.transform.DOKill();
        _scoreText.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        _scoreText.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        switch (tileTapStatus)
        {
            case TileTapStatus.Good:
                _tapStatusText.text = "Good";
                break;
            case TileTapStatus.Great:
                _tapStatusText.text = "Great";
                break;
            case TileTapStatus.Perfect:
                _tapStatusText.text = "Perfect";
                break;

        }
        _tapStatusText.transform.localScale = Vector3.zero;
        _tapStatusText.transform
            .DOScale(1f, 0.25f)
            .SetEase(Ease.OutBack)
            .OnComplete(() =>
            {
                _tapStatusText.transform.DOScale(0f, 0.5f).SetEase(Ease.Linear);
            });
    }
    // Update is called once per frame
    void Update()
    {

    }
}
