using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ColorThemeText : MonoBehaviour
{
    public Color original;

    private void Awake()
    {
        original = Text.color;
    }
    public TMP_Text Text
    {
        get
        {
            return GetComponent<TMP_Text>();
        }
    }
}
