using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileComments : MonoBehaviour
{
    [SerializeField] private Transform comments;

    public void ToggleComment(int value)
    {
        GameObject note = comments.GetChild(value - 1).gameObject;
        note.SetActive(!note.activeSelf);
    }

    public void ClearComments()
    {
        for (int i = 0; i < comments.childCount; i++) 
        {
            comments.GetChild(i).gameObject.SetActive(false);
        }
    }
}
