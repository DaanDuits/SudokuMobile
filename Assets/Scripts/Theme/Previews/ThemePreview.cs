using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemePreview : MonoBehaviour
{
    private ColorThemeSelector _selector => FindFirstObjectByType<ColorThemeSelector>();

    [SerializeField] private TMP_Text[] text;
    [SerializeField] private Image[] images;
    [SerializeField] private Image background;

    private ColorThemePreset _preset;
    public ColorThemePreset Preset
    {
        set
        {
            _preset = value;
            GetComponent<Button>().onClick.AddListener(() => { _selector.OnPresetSelected(_preset);  });
            SetColors();
        }
    }

    private void SetColors()
    {
        background.color = _preset.backgroundColor;
        for (int i = 0; i < text.Length; i++) 
        {
            text[i].color *= _preset.textColor;
        }
        for (int i = 0;i < images.Length; i++)
        {
            images[i].color *= _preset.imageColor;
        }
    }
}
