using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColorThemeHandler : MonoBehaviour
{
    [SerializeField] private ColorThemeImage[] images;
    [SerializeField] private ColorThemeButton[] buttons;
    [SerializeField] private ColorThemeTile[] tiles;
    [SerializeField] private ColorThemeText[] text;
    [SerializeField] private ColorThemePreset defaultPreset;
 
    public ColorThemePreset Preset
    {
        set
        {
            _colorTheme = new ColorTheme(value);
            ResetColors();
            SetColors();
        }
    }
    private ColorTheme _colorTheme;

    private void OnLevelWasLoaded(int level)
    {
        ResetColors();
        SetColors();
    }

    private void GetObjects()
    {
        images = FindObjectsByType<ColorThemeImage>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        buttons = FindObjectsByType<ColorThemeButton>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        tiles = FindObjectsByType<ColorThemeTile>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        text = FindObjectsByType<ColorThemeText>(FindObjectsInactive.Include, FindObjectsSortMode.None);
    }

    private void ResetColors()
    {
        GetObjects();

        Camera.main.backgroundColor = defaultPreset.backgroundColor;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].Image.color = defaultPreset.imageColor * images[i].original;
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            ColorBlock buttonBlock = buttons[i].Button.colors;
            buttonBlock.pressedColor = defaultPreset.buttonSelected;
            buttons[i].Button.colors = buttonBlock;
        }
        for (int i = 0; i < tiles.Length; i++)
        {
            ColorBlock tileBlock = tiles[i].Tile.colors;
            tileBlock.selectedColor *= defaultPreset.tileHighlighted;
            tileBlock.pressedColor *= defaultPreset.tileHighlighted;
            tileBlock.normalColor *= defaultPreset.tileSelected;
            tiles[i].Tile.colors = tileBlock;
        }
        for (int i = 0; i < text.Length; i++)
        {
            text[i].Text.color = defaultPreset.textColor * text[i].original;
        }
    }

    private void SetColors()
    {
        GetObjects();

        Camera.main.backgroundColor = _colorTheme.backgroundColor;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].Image.color *= _colorTheme.imageColor;
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            ColorBlock buttonBlock = buttons[i].Button.colors;
            buttonBlock.pressedColor *= _colorTheme.buttonSelected;
            buttons[i].Button.colors = buttonBlock;
        }
        for (int i = 0; i < tiles.Length; i++)
        {
            ColorBlock tileBlock = tiles[i].Tile.colors;
            tileBlock.selectedColor *= _colorTheme.tileSelected;
            tileBlock.pressedColor *= _colorTheme.tileSelected;
            tileBlock.normalColor *= _colorTheme.tileHighlighted;
            tiles[i].Tile.colors = tileBlock;
        }
        for (int i = 0; i < text.Length; i++)
        {
            text[i].Text.color *= _colorTheme.textColor;
        }
    }
}
