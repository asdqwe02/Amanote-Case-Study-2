using DG.Tweening;
using UnityEngine;
[CreateAssetMenu(fileName = "TileConfig.asset", menuName = "Game/TileConfig", order = 0)]
public class TileConfig : ScriptableObject
{


    [Header("General Configs")]
    public float speed;
    public Sprite tileSprite;
    public Ease easeType;
    public float longNoteTileHoldDuration;
    public float perfectTimeThreshold;
    public float greatTimeThreshold;

    [Header("Nomral Tile Config")]
    public float normalTileSpawnDelay;

    [Header("Long Tile Configs")]
    public float longTileScoreTickTime;
    public float longNoteTileSpawnDelay;
    public float tileLength => tileSprite.rect.height;
}