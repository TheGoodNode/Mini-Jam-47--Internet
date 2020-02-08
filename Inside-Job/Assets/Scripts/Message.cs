using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MessageTypes
{
    Authentication,
    Read
}

public class Message : MonoBehaviour
{
    public string messageText;
    public MessageTypes messageType;

    private void Start()
    {
        messageType = AssignMessageType();
        messageText = HandleReturnMessageText();
    }


    private string[] AuthenticationText =
    {
        "SignIn",
        "logIn"
    };

    private string[] Read =
    {
        "list news feed",
        "open profile page"
    };

    private string HandleReturnMessageText()
    {
        System.Random random = new System.Random();
        int index;
        switch (messageType)
        {
            case MessageTypes.Authentication:
                index = random.Next(0, AuthenticationText.Length);
                Debug.Log("here" + index);
                Debug.Log("here" + AuthenticationText[index]);
                return AuthenticationText[index];

            case MessageTypes.Read:
                index = random.Next(0, Read.Length);
                Debug.Log("here" + index);
                Debug.Log("here" + Read[index]);
                return Read[index];
            default:
                return "";
        }
    }



    private MessageTypes AssignMessageType()
    {
        Array values = Enum.GetValues(typeof(MessageTypes));
        System.Random random = new System.Random();
        MessageTypes randomMessageType = (MessageTypes)values.GetValue(random.Next(values.Length));
        return randomMessageType;
    }

}
