using DG.Tweening;
using UnityEngine;
[CreateAssetMenu(fileName = "TileConfig.asset", menuName = "Game/TileConfig", order = 0)]
public class TileConfig : ScriptableObject
{
    public float speed;
    public Ease easeType;
}