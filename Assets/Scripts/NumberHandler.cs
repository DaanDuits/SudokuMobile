using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberHandler : MonoBehaviour
{
    [SerializeField] private Color textColorOff, textColorOn;

    public void TurnOffNumber(int number)
    {
        Transform button = transform.GetChild(number);
        button.GetComponent<Button>().interactable = false;
        TMP_Text text = button.GetChild(0).GetComponent<TMP_Text>();
        text.color = textColorOff;
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
        text.color = textColorOn;
    }

    public void ResetNumbers()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform button = transform.GetChild(i);
            button.GetComponent<Button>().interactable = true;
            TMP_Text text = button.GetChild(0).GetComponent<TMP_Text>();
            text.color = textColorOn;
        }
    }
}