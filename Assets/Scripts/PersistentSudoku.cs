using DataPersistence;
using DataPersistence.Data;
using TMPro;
using UnityEngine;

public class PersistentSudoku : PersistentDataBehaviour
{
    [PersistentProperty] private float _difficultyPercentage { get; set; }
    [PersistentProperty] private int _seed { get; set; }

    [PersistentProperty] private TileData[,] Sudoku { get; set; }

    private static GameObject singleton;

    private void Start()
    {
        if (singleton != null)
        {
            Destroy(singleton);
        }
        singleton = gameObject;
        DontDestroyOnLoad(gameObject);
    }

    public SudokuData LoadSudoku()
    {
        Load();

        return new SudokuData(_difficultyPercentage, _seed, Sudoku);
    }

    public void SaveSudoku(Tile[,] sudoku, int seed, float difficulty)
    {
        _seed = seed;
        _difficultyPercentage = difficulty;

        Sudoku = new TileData[sudoku.GetLength(0), sudoku.GetLength(1)];
        for (int i = 0; i < sudoku.GetLength(0); i++)
        {
            for (int j = 0; j < sudoku.GetLength(1); j++)
            {
                Sudoku[i, j] = new TileData(sudoku[i, j]);
            }
        }
        Save();
    }


}