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
    public MessageTypes messageType;

    public float messageDelay = 5;
    float countDown;

    [SerializeField]public TextMesh timer;

    [HideInInspector]
    public string messageText;
    public TextMesh MessageText;

    public TextMesh responseTimer;
    private float responseTimeDelay = 3.0f;

    public GameObject ReadyText;

    private void Start()
    {
        responseTimer.text = Convert.ToInt32(responseTimeDelay).ToString();
        countDown = messageDelay;
        timer.text = countDown.ToString();
        messageType = AssignMessageType();
        messageText = HandleReturnMessageText();
        MessageText.text = messageText;
    }

    [HideInInspector] public bool startedCreatingResponse = false;
    [HideInInspector] public bool responseMessageIsReady = false;
    [HideInInspector] public bool MessageIsReady = false;
    private void Update()
    {
        if(countDown >= 0)
        {
            countDown -= Time.deltaTime;
            //GameManager.instance.EndGame();
            timer.text = Convert.ToInt32(countDown).ToString();
        }

        if (startedCreatingResponse)
        {
            if (responseTimeDelay >= 0)
            {
                responseTimeDelay -= Time.deltaTime;
                responseTimer.text = Convert.ToInt32(responseTimeDelay).ToString();
                if (responseTimeDelay <= 0)
                {
                    ReadyText.gameObject.SetActive(true);
                    startedCreatingResponse = false;
                    responseMessageIsReady = true;
                }
            }
        }
    }

    public void GetDestoryed()
    {
        gameObject.GetComponent<Animation>().Play("DestroyAnimation");
        gameObject.GetComponent<Animation>().wrapMode = WrapMode.Once;
        //float duration = gameObject.GetComponent<Animation>().clip.length;
        Destroy(gameObject, 2.0f);
    }


    public void SendResponseToUser()
    {
        gameObject.GetComponent<Animation>().Play("SendResponse");
        gameObject.GetComponent<Animation>().wrapMode = WrapMode.Once;
        //float duration = gameObject.GetComponent<Animation>().clip.length;
        Destroy(gameObject, 2.0f);
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
                return AuthenticationText[index];

            case MessageTypes.Read:
                index = random.Next(0, Read.Length);
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
