using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileComments : MonoBehaviour
{
    [SerializeField] private Transform comments;

    private void Start()
    {
        ClearComments();
    }

    public void ToggleComment(int value)
    {
        comments.GetChild(value - 1).gameObject.SetActive(!comments.GetChild(value - 1).gameObject.activeSelf);
    }

    public void ClearComments()
    {
        for (int i = 0; i < comments.childCount; i++) 
        {
            comments.GetChild(i).gameObject.SetActive(false);
        }
    }
}
