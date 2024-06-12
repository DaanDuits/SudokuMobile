using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ColorThemeButton : MonoBehaviour
{
    public Button Button
    {
        get
        {
            return GetComponent<Button>();
        }
    }
}