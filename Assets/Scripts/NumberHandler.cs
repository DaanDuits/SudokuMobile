using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NumberHandler : MonoBehaviour
{
    [SerializeField] private Color textColorOff, textColorOn;
    [SerializeField] private Image commentButton;
    [SerializeField] private Sprite commentingOn, commentingOff;

    private Color _defaultTextColor;

    private bool _comment;

    public void SetComments()
    {
        Tile.SetComment();
        _comment = !_comment;
        commentButton.sprite = _comment ? commentingOn : commentingOff;
    }

    public void TurnOffNumber(int number)
    {
        Transform button = transform.GetChild(number);
        button.GetComponent<Button>().interactable = false;
        TMP_Text text = button.GetChild(0).GetComponent<TMP_Text>();
        _defaultTextColor = text.color;
        text.color = textColorOff * _defaultTextColor;
    }

    public bool IsInteractable(int number)
    {
        return transform.GetChild(number).GetComponent<Button>().interactable;
    }

    public void TurnOnNumber(int number)
    {
        Transform button = transform.GetChild(number);
        button.GetComponent<Button>().interactable = true;
        TMP_Text text = button.GetChild(0).GetComponent<TMP_Text>();
        text.color = textColorOn * _defaultTextColor;
    }

    public void ResetNumbers()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform button = transform.GetChild(i);
            button.GetComponent<Button>().interactable = true;
            TMP_Text text = button.GetChild(0).GetComponent<TMP_Text>();
            text.color = textColorOn * _defaultTextColor;
        }
    }
}