using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ColorThemeTile : MonoBehaviour
{
    public Toggle Tile
    {
        get
        {
            return GetComponent<Toggle>();
        }
    }
}