using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ColorTheme
{
    public Color imageColor;
    public Color backgroundColor;
    public Color textColor;
    public Color buttonSelected;
    public Color tileHighlighted;
    public Color tileSelected;

    public ColorTheme(ColorThemePreset preset)
    {
        imageColor = preset.imageColor;
        backgroundColor = preset.backgroundColor;
        textColor = preset.textColor;
        buttonSelected = preset.buttonSelected;
        tileHighlighted = preset.tileHighlighted;
        tileSelected = preset.tileSelected;
    }
}
