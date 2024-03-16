
using System;
public static class SystemSignal
{
    public static Action<TileTapStatus> tileTapEvent;
    public static Action<Tile> getTileEvent;
    public static Action returnTileEvent;
    public static void TileTap(TileTapStatus tileTapStatus)
    {
        tileTapEvent?.Invoke(tileTapStatus);
    }
}
