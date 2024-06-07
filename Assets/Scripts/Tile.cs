using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tile
{
    private TMP_Text _display;
    private TileComments _comments;
    public List<int> ActiveComments;
    private int _value;
    private bool _isLocked;

    private bool _loadedValue;

    private static bool _comment;

    public static void SetComment()
    {
        _comment = !_comment;
    }

    public Tile(TMP_Text display, List<int> activeComments, int value = 0, bool loadedValue = false)
    {
        _comment = false;
        ActiveComments = activeComments;
        _display = display;
        _comments = _display.GetComponent<TileComments>();

        _loadedValue = loadedValue;
        Value = value;

        for (int i = 0; i < ActiveComments.Count; i++)
        {
            _comments.ToggleComment(ActiveComments[i]);
        }
    }

    public void Lock(Color32 color)
    {
        _display.color = color;
        _isLocked = true;
    }
    public void Unlock(Color32 color)
    {
        _display.color = color;
        _isLocked = false;
    }

    public bool Locked()
    {
        return _isLocked;
    }

    private void AddRemoveComment(int comment)
    {
        if (ActiveComments.Contains(comment))
        {
            ActiveComments.Remove(comment);
            return;
        }
        ActiveComments.Add(comment);
    }

    private void ClearComments()
    {
        _comments.ClearComments();
        ActiveComments.Clear();
    }

    public int Value
    {
        get { return _value; }
        set
        {
            if (_comment)
            {
                if (value == 0 && _value == 0)
                {
                    ClearComments();
                }

                _comments.ToggleComment(value);
                AddRemoveComment(value);
                return;
            }

            if (!_loadedValue)
            {
                _comments.ClearComments();
            }

            if (value == 0)
            {
                for (int i = 0; i < ActiveComments.Count; i++)
                {
                    _comments.ToggleComment(ActiveComments[i]);
                }
            }


            bool isOutOfRange = value < 0 || value > 9;
            if (_isLocked || isOutOfRange)
            {
                return;
            }
            _value = value;

            _display.text = value == 0 ? "" : value.ToString();

            _loadedValue = false;
        }
    }
}