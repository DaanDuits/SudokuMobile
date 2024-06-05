using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class MessageCreator : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text body;
    [SerializeField] private TMP_Text buttonLeftText, buttonRightText;
    [SerializeField] private Button buttonLeft, buttonRight;

    public static MessageCreator instance;

    private void Start()
    {
        if (instance != null)
        {
            throw new System.Exception("There already is an instance of the singleton class MessageCreator!");
        }
        instance = this; 
        gameObject.SetActive(false);
    }

    public static void CreateNewMessage(MessageData message)
    {
        instance.gameObject.SetActive(true);

        instance.title.text = message.Title;
        instance.body.text = message.Body;
        instance.buttonLeftText.text = message.ButtonNameLeft;
        instance.buttonRightText.text = message.ButtonNameRight;

        instance.buttonLeft.onClick = message.ButtonLeftAction;
        instance.buttonLeft.onClick.AddListener(() => { instance.gameObject.SetActive(false); });
        instance.buttonRight.onClick = message.ButtonRightAction;
        instance.buttonRight.onClick.AddListener(() => {  instance.gameObject.SetActive(false); });
    }
}