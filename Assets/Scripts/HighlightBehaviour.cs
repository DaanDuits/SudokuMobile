using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HighlightBehaviour : MonoBehaviour
{
    [SerializeField] private BoardGeneration generation;
    private const int _size = 9;
    private List<Transform> highlighted = new List<Transform>();

    [SerializeField] private Color32 highlightedColor = Color.white;
    private Color32 transparent = new Color32(255, 255, 255, 0);

    public void ClearHiglighted()
    {
        for (int i = 0; i < highlighted.Count; i++)
        {
            var colors = highlighted[i].GetComponent<Toggle>().colors;
            colors.normalColor = transparent;
            highlighted[i].GetComponent<Toggle>().colors = colors;
        }
        highlighted.Clear();
    }
    public void Highlight()
    {
        if (!generation.hasStarted)
        {
            return;
        }
        ClearHiglighted();
        Toggle t = generation.tileGroup.ActiveToggles().Single();
        int index = t.transform.GetSiblingIndex();
        int x = index / _size;
        int y = index % _size;

        int highlightedValue = generation.sudoku[y, x].Value;

        if (highlightedValue == 0)
        {
            return;
        }
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (generation.sudoku[i, j].Value == highlightedValue && generation.board.GetChild(j * _size + i) != t.transform)
                {
                    highlighted.Add(generation.board.GetChild(j * _size + i));
                    var colors = generation.board.GetChild(j * _size + i).GetComponent<Toggle>().colors;
                    colors.normalColor = highlightedColor;
                    generation.board.GetChild(j * _size + i).GetComponent<Toggle>().colors = colors;
                }
            }
        }

    }
}