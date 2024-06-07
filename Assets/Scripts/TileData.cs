using DataPersistence.Data;
using System.Collections.Generic;

public struct TileData
{
    public TileData(Tile tile)
    {
        Value = tile.Value;
        IsLocked = tile.Locked();
        ActiveComments = tile.ActiveComments;
    }

    [PersistentProperty] public int Value { get; set; }
    [PersistentProperty] public bool IsLocked { get; set; }
    [PersistentProperty] public List<int> ActiveComments { get; set; }
}