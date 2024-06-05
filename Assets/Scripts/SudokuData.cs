public struct SudokuData
{
    public float DifficultyPercentage;
    public int Seed;
    public TileData[,] Sudoku;

    public SudokuData(float difficultyPercentage, int seed, TileData[,] sudoku)
    {
        DifficultyPercentage = difficultyPercentage;
        Seed = seed;
        Sudoku = sudoku;
    }
}