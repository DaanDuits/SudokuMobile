using System;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public struct MessageData
{
    public string Title;
    public string Body;
    public string ButtonNameLeft, ButtonNameRight;
    public Button.ButtonClickedEvent ButtonLeftAction, ButtonRightAction;

    public MessageData(string title, string body, string buttonLeft, string buttonRight, Button.ButtonClickedEvent buttonLeftAction, Button.ButtonClickedEvent buttonRightAction)
    {
        Title = title;
        Body = body;
        ButtonNameLeft = buttonLeft;
        ButtonNameRight = buttonRight;
        ButtonLeftAction = buttonLeftAction;
        ButtonRightAction = buttonRightAction;
    }
}
