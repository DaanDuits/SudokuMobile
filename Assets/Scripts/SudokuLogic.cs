using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SudokuLogic : MonoBehaviour
{
    [SerializeField] private UnityEvent onWin;
    [SerializeField] private MessageData winMessage;
    [SerializeField] private HighlightBehaviour highlightBehaviour;
    [SerializeField] private BoardGeneration generation;
    [SerializeField] private NumberHandler numberHandler;
    private const int _size = 9;
    private const int _subgridSize = 3;

    private void Start()
    {
        for (int i = 1; i <= _size; i++)
        {
            if (isNumberSolved(i))
            {
                numberHandler.TurnOffNumber(i - 1);
            }
        }
    }

    public void ChangeNumber(int value)
    {
        Toggle t = generation.tileGroup.ActiveToggles().Single();
        t.isOn = false;
        highlightBehaviour.ClearHiglighted();
        int index = t.transform.GetSiblingIndex();
        int x = index / _size;
        int y = index % _size;

        generation.sudoku[y, x].Value = value;
        generation.Save();

        if (isSudokuSolved())
        {
            MessageCreator.CreateNewMessage(winMessage);
            onWin.Invoke();
        }

        if (isNumberSolved(value)) 
        {
            numberHandler.TurnOffNumber(value - 1);
        }

        for (int i = 1; i <= _size; i++)
        {
            if (i == value)
            {
                continue;
            }
            if (!isNumberSolved(i) && !numberHandler.IsInteractable(i - 1))
            {
                numberHandler.TurnOnNumber(i - 1);
            }
        }

        if (value != 0)
        {
            return;
        }

        for (int i = 1; i <= _size; i++)
        {
            if (isNumberSolved(i) && numberHandler.IsInteractable(i - 1))
            {
                numberHandler.TurnOffNumber(i - 1);
            }
        }
    }

    private bool isNumberSolved(int number)
    {
        if (number == 0)
        {
            return false;
        }

        for (int i = 0; i < _size; i++)
        {
            List<int> rowSet = new List<int>();
            List<int> colSet = new List<int>();
            for (int j = 0; j < _size; j++)
            {
                if (generation.sudoku[i, j].Value == number)
                {
                    if (rowSet.Contains(generation.sudoku[i, j].Value))
                    {
                        return false;
                    }
                    rowSet.Add(generation.sudoku[i, j].Value);
                }
                if (generation.sudoku[j, i].Value == number)
                {
                    if (colSet.Contains(generation.sudoku[j, i].Value))
                    {
                        return false;
                    }
                    colSet.Add(generation.sudoku[j, i].Value);
                }
            }

            if (rowSet.Count == 0 || colSet.Count == 0)
            {
                return false;
            }
        }


        for (int i = 0; i < _size; i += _subgridSize)
        {
            for (int j = 0; j < _size; j += _subgridSize)
            {
                List<int> subgridSet = new List<int>();
                for (int k = 0; k < _subgridSize; k++)
                {
                    for (int l = 0; l < _subgridSize; l++)
                    {
                        int num = generation.sudoku[i + k, j + l].Value;
                        if (num == number)
                        {
                            if (subgridSet.Contains(num))
                            {
                                return false;
                            }
                            subgridSet.Add(num);
                        }
                    }
                }

                if (subgridSet.Count == 0)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private bool isSudokuSolved()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (generation.sudoku[i,j].Value == 0)
                {
                    return false;
                }
            }
        }

        for (int i = 0; i < _size; i++)
        {
            List<int> rowSet = new List<int>();
            List<int> colSet = new List<int>();
            for (int j = 0; j < _size; j++)
            {
                if (generation.sudoku[i,j].Value != 0)
                {
                    if (rowSet.Contains(generation.sudoku[i, j].Value))
                    {
                        return false;
                    }
                    rowSet.Add(generation.sudoku[i,j].Value);
                }
                if (generation.sudoku[j, i].Value != 0)
                {
                    if (colSet.Contains(generation.sudoku[j, i].Value))
                    {
                        return false;
                    }
                    colSet.Add(generation.sudoku[j, i].Value);
                }
            }
        }


        for (int i = 0; i < _size; i += _subgridSize)
        {
            for (int j = 0; j < _size; j += _subgridSize)
            {
                List<int> subgridSet = new List<int>();
                for (int k = 0; k < _subgridSize; k++)
                {
                    for (int l = 0; l < _subgridSize; l++)
                    {
                        int num = generation.sudoku[i + k, j + l].Value;
                        if (num != 0)
                        {
                            if (subgridSet.Contains(num))
                            {
                                return false;
                            }
                            subgridSet.Add(num);
                        }
                    }
                }
            }
        }

        return true;
    }
}