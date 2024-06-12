using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColorThemeHandler : MonoBehaviour
{
    [SerializeField] private ColorThemeImage[] images;
    [SerializeField] private ColorThemeButton[] buttons;
    [SerializeField] private ColorThemeTile[] tiles;
    [SerializeField] private TMP_Text[] text;
    [SerializeField] private ColorThemePreset defaultPreset;
    [SerializeField] private ColorThemePreset test;
 
    public ColorThemePreset Preset
    {
        set
        {
            _colorTheme = new ColorTheme(value);
            ResetColors();
        }
    }
    private ColorTheme _colorTheme;
    private void Start()
    {
        Preset = test;
    }


    private void OnLevelWasLoaded(int level)
    {
        ResetColors();
    }

    private void ResetColors()
    {
        images = FindObjectsByType<ColorThemeImage>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        buttons = FindObjectsByType<ColorThemeButton>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        tiles = FindObjectsByType<ColorThemeTile>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        text = FindObjectsByType<TMP_Text>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        Camera.main.backgroundColor = defaultPreset.backgroundColor;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].Image.color *= defaultPreset.imageColor;
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
            tileBlock.selectedColor = defaultPreset.tileHighlighted;
            tileBlock.pressedColor = defaultPreset.tileHighlighted;
            tileBlock.normalColor = defaultPreset.tileSelected;
            tiles[i].Tile.colors = tileBlock;
        }
        for (int i = 0; i < text.Length; i++)
        {
            text[i].color = defaultPreset.textColor;
        }
        SetColors();
    }

    private void SetColors()
    {
        images = FindObjectsByType<ColorThemeImage>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        buttons = FindObjectsByType<ColorThemeButton>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        tiles = FindObjectsByType<ColorThemeTile>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        text = FindObjectsByType<TMP_Text>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        Camera.main.backgroundColor *= _colorTheme.backgroundColor;
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
            text[i].color *= _colorTheme.textColor;
        }
    }
}
