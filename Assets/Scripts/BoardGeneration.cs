using System.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoardGeneration : MonoBehaviour
{
    public ToggleGroup tileGroup;
    public Transform board;
    private PersistentSudoku persistentSudoku;
    private StartupBehaviour startupBehaviour;
    [SerializeField] private MessageData resetMessage, restartMessage;

    private const int _size = 9;
    private const int _subgridSize = 3;
    public Tile[,] sudoku = new Tile[_size, _size];
    private float _difficultyPercentage = 0.6f;
    private int _seed;
    private const int totalCells = _size * _size;

    [SerializeField] private HighlightBehaviour highlightBehaviour;

    [SerializeField] private Color32 unlockedColor = Color.white;
    [SerializeField] private Color32 lockedColor = Color.white;

    public bool hasStarted = false;


    private void Start()
    {
        persistentSudoku = FindAnyObjectByType<PersistentSudoku>();
        startupBehaviour = FindAnyObjectByType<StartupBehaviour>();
        if (persistentSudoku.CanLoad && startupBehaviour.canContinue())
        {
            SudokuData data = persistentSudoku.LoadSudoku();
            _difficultyPercentage = data.DifficultyPercentage;
            _seed = data.Seed;

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    sudoku[i, j] = new Tile(board.GetChild(j * _size + i).GetChild(0).GetComponent<TMP_Text>(), data.Sudoku[i, j].ActiveComments, data.Sudoku[i, j].Value, true);
                    if (data.Sudoku[i, j].IsLocked) sudoku[i, j].Lock(lockedColor);
                    else sudoku[i, j].Unlock(unlockedColor);
                }
            }
            hasStarted = true;
            Random.InitState(_seed);
            return;
        }

        GenerateSeed();
        _difficultyPercentage = startupBehaviour.difficultyPercentage;
        Random.InitState(_seed);
        GenerateSudoku();
        hasStarted = true;
    }

    public void Save()
    {
        persistentSudoku.SaveSudoku(sudoku, _seed, _difficultyPercentage);
    }

    private void GenerateSeed()
    {
        _seed = Random.Range(-100000, 100000);
    }

    public void RestartRequest(bool resetSeed)
    {
        MessageCreator.CreateNewMessage(resetSeed ? resetMessage : restartMessage);
    }

    public void Restart(bool resetSeed)
    {
        if (resetSeed)
        {
            GenerateSeed();
        }

        Random.InitState(_seed);
        highlightBehaviour.ClearHiglighted();
        GenerateSudoku();
    }

    private void GenerateSudoku()
    {
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                sudoku[i, j] = new Tile(board.GetChild(j * _size + i).GetChild(0).GetComponent<TMP_Text>(), new List<int>());
            }
        }


        FillGrid();

        RemoveNumbers();

        LockGenerated();
    }

    void FillGrid()
    {
        FillDiagonal();

        SolveSudoku();
    }

    void FillDiagonal()
    {
        for (int i = 0; i < _size; i += _subgridSize)
        {
            FillSubgrid(i, i);
        }
    }

    void FillSubgrid(int row, int col)
    {
        int[] nums = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Shuffle(nums);

        int index = 0;
        for (int i = 0; i < _subgridSize; i++)
        {
            for (int j = 0; j < _subgridSize; j++)
            {
                sudoku[row + i, col + j].Value = nums[index];
                index++;
            }
        }
    }

    void Shuffle(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Mathf.FloorToInt(Random.value * (i + 1));
            var arraySave = array[i];
            array[i] = array[j];
            array[j] = arraySave;
        }
    }

    private bool SolveSudoku()
    {
        for (int row = 0; row < _size; row++)
        {
            for (int col = 0; col < _size; col++)
            {
                if (sudoku[row, col].Value == 0)
                {
                    for (int num = 1; num <= _size; num++)
                    {
                        if (IsValid(row, col, num))
                        {
                            sudoku[row, col].Value = num;
                            if (SolveSudoku())
                            {
                                return true;
                            }
                            sudoku[row, col].Value = 0;
                        }
                    }
                    return false;
                }
            }
        }
        return true;
    }

    private bool IsValid(int row, int col, int num)
    {
        return
            !UsedInRow(row, num) &&
            !UsedInCol(col, num) &&
            !UsedInSubgrid(row - (row % 3), col - (col % 3), num);
    }

    private bool UsedInRow(int row, int num)
    {
        for (int col = 0; col < _size; col++)
        {
            if (sudoku[row, col].Value == num)
            {
                return true;
            }
        }
        return false;
    }

    private bool UsedInCol(int col, int num)
    {
        for (int row = 0; row < _size; row++)
        {
            if (sudoku[row, col].Value == num)
            {
                return true;
            }
        }
        return false;
    }

    private bool UsedInSubgrid(int startRow, int startCol, int num)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (sudoku[row + startRow, col + startCol].Value == num)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void RemoveNumbers()
    {
        int cellsToRemove = Mathf.FloorToInt(totalCells * _difficultyPercentage);

        for (int i = 0; i < cellsToRemove; i++)
        {
            int row = Mathf.FloorToInt(Random.value * _size);
            int col = Mathf.FloorToInt(Random.value * _size);
            if (sudoku[row, col].Value != 0)
            {
                sudoku[row, col].Unlock(unlockedColor); 
                sudoku[row, col].Value = 0;
            }
            else
            {
                i--;
            }
        }
    }

    private void LockGenerated()
    {
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (sudoku[i, j].Value != 0)
                {
                    sudoku[i, j].Lock(lockedColor);
                }   
            }
        }
    }
}