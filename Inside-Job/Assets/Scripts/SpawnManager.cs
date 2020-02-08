using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(CreateMessage());
    }

    private void Update()
    {

    }


    IEnumerator CreateMessage()
    {
        yield return new WaitForSeconds(3f);

        Debug.Log("hello World");
        Message message = new Message();
        Debug.Log(message.messageText);
        Debug.Log(message.messageType);

    }

}


enum MessageTypes
{
    Authentication,
    Read
}

class Message
{
    public string messageText { get; set; }
    public MessageTypes messageType { get; set; }

    public Message()
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
        int index;
        switch (messageType)
        {
            case MessageTypes.Authentication:
                 index = UnityEngine.Random.Range(0, AuthenticationText.Length);
                return AuthenticationText[index];

            case MessageTypes.Read:
                 index = UnityEngine.Random.Range(0, Read.Length);
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