using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewColorTheme",menuName = "Color Theme")]
public class ColorThemePreset : ScriptableObject
{
    [Header("Image")]
    public Color imageColor;
    [Header("Background")]
    public Color backgroundColor;
    [Header("Text")]
    public Color textColor;
    [Header("Button")]
    public Color buttonSelected;
    [Header("Tile")]
    public Color tileHighlighted;
    public Color tileSelected;
}
