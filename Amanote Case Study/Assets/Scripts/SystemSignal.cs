
using System;

public static class SystemSignal
{
    public static Action<Tile> tileClickEvent;
    public static void TileClick(Tile tile)
    {
        tileClickEvent?.Invoke(tile);
    }
}
