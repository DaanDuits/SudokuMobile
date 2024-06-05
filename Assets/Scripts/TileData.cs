using DataPersistence.Data;
public struct TileData
{
    public TileData(Tile tile)
    {
        Value = tile.Value;
        IsLocked = tile.Locked();
    }

    [PersistentProperty] public int Value { get; set; }
    [PersistentProperty] public bool IsLocked { get; set; }
}