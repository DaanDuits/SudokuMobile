using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorThemeImage : MonoBehaviour
{
    public Image Image
    {
        get
        {
            return GetComponent<Image>();
        }
    }
}
