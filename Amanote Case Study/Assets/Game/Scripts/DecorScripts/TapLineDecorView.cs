using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TapLineDecorView : MonoBehaviour
{
    [SerializeField] private Image _effectImage;
    [Header("Effect Config")]
    [SerializeField] private float _effectTime;
    [SerializeField] private float _alphaColor;

    // Start is called before the first frame update
    void Start()
    {
        _effectImage
            .DOColor(new Color(1f, 1f, 1f, _alphaColor), _effectTime)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
