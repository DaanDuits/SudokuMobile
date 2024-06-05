using TMPro;
using UnityEngine;

public class Tile
{
    private TMP_Text _display;
    private int _value;
    private bool _isLocked;

    public Tile(TMP_Text display, int value)
    {
        _display = display;
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
            bool isOutOfRange = value < 0 || value > 9;
            if (_isLocked || isOutOfRange)
            {
                return;
            }
            _value = value;

            _display.text = value == 0 ? "" : value.ToString();
        }
    }
}