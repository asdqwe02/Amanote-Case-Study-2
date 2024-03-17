using DG.Tweening;
using UnityEngine;
[CreateAssetMenu(fileName = "TileConfig.asset", menuName = "Game/TileConfig", order = 0)]
public class TileConfig : ScriptableObject
{
    public float speed;
    public Sprite tileSprite;
    public Ease easeType;
    public float longNoteTileHoldDuration;
    public float perfectTimeThreshold;
    public float greatTimeThreshold;
    public float normalTileSpawnDelay;
    public float longNoteTileSpawnDelay;
    public float tileLength => tileSprite.rect.height / 2f;
}