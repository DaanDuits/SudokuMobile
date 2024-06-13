using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewColorTheme",menuName = "Color Theme")]
public class ColorThemePreset : ScriptableObject
{
    [Header("Image")]
    public Color imageColor = Color.black;
    [Header("Background")]
    public Color backgroundColor = Color.black;
    [Header("Text")]
    public Color textColor = Color.black;
    [Header("Button")]
    public Color buttonSelected = Color.black;
    [Header("Tile")]
    public Color tileHighlighted = Color.black;
    public Color tileSelected = Color.black;
}
