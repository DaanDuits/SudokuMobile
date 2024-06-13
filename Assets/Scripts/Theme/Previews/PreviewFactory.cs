using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewFactory : MonoBehaviour
{
    public static PreviewFactory instance;
    [SerializeField] private GameObject colorThemePreview;

    private void Awake()
    {
        instance = this;
    }

    public static void CreateColorPreview(Transform parent, ColorThemePreset preset)
    {
        GameObject preview = Instantiate(instance.colorThemePreview, parent);
        preview.GetComponent<ThemePreview>().Preset = preset;
    }
}
