using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ColorThemeSelector : MonoBehaviour
{
    private ColorThemeHandler _handler;
    [SerializeField] private PersistentTheme _persistentTheme;
    [SerializeField] private ColorThemePreset[] presets;
    [SerializeField] private Transform previewList;

    private void Start()
    {
        for (int i = 0; i < presets.Length; i++) 
        {
            PreviewFactory.CreateColorPreview(previewList, presets[i]);
        }
        _persistentTheme = GetComponent<PersistentTheme>();
        previewList.transform.parent.gameObject.SetActive(false);
        StartCoroutine(GetHandler());   
    }

    private IEnumerator GetHandler()
    {
        while (_handler == null)
        {
            yield return null;
            if (FindObjectsByType<ColorThemeHandler>(FindObjectsInactive.Include, FindObjectsSortMode.None).Length == 1) 
            {
                _handler = FindFirstObjectByType<ColorThemeHandler>();
                _handler.Preset = presets[_persistentTheme.ThemeIndex];
                break;
            }
        }
    }

    public void OnPresetSelected(ColorThemePreset preset)
    {
        _handler.Preset = preset;
        for (int i = 0; i < presets.Length; i++)
        {
            if (presets[i] == preset)
            {
                _persistentTheme.ThemeIndex = i;
                break;
            }
        }
        _persistentTheme.Save();
    }
}