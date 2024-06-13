using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorThemeImage : MonoBehaviour
{
    public Color original;

    private void Awake()
    {
        original = Image.color;
    }
    public Image Image
    {
        get
        {
            return GetComponent<Image>();
        }
    }
}
