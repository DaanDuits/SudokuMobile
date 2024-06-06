using TMPro;
using UnityEngine;

public class Tile
{
    private TMP_Text _display;
    private TileComments _comments;
    private int _value;
    private bool _isLocked;

    private static bool _comment;

    public static void SetComment()
    {
        _comment = !_comment;
    }

    public Tile(TMP_Text display, int value)
    {
        _display = display;
        _comments = _display.GetComponent<TileComments>();
        Value = value;
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

    public int Value
    {
        get { return _value; }
        set
        {
            if (_comment)
            {
                _comments.ToggleComment(value);
                return;
            }


            bool isOutOfRange = value < 0 || value > 9;
            if (_isLocked || isOutOfRange)
            {
                return;
            }
            _value = value;

            _display.text = value == 0 ? "" : value.ToString();
            _comments.ClearComments();
        }
    }
}