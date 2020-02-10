using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MessagesEntryPosition
{
    public GameObject messageSlot;
    [HideInInspector]
    public bool slotIsAquired = false;
}

public class EntryPoint : MonoBehaviour
{
    
    public enum EntryPointType
    {
        request,
        response,
        responseSender,
        messageDestroyer
    }

    public EntryPointType entryPointType;


    public entry currentEntryPoint;
    
    public List<MessagesEntryPosition> messageEntryPos;
    [HideInInspector]
    public List<Transform> arrayOfMessages = new List<Transform>(1);


    private void Awake()
    {
        switch (entryPointType)
        {
            case EntryPointType.request:
                currentEntryPoint = new Request(messageEntryPos, arrayOfMessages);
                break;

            case EntryPointType.response:
                currentEntryPoint = new Response(messageEntryPos, arrayOfMessages);
                break;

            case EntryPointType.messageDestroyer:
                currentEntryPoint = new MessageDestroyer(messageEntryPos);
                break;

            case EntryPointType.responseSender:
                currentEntryPoint = new ResponseSender(messageEntryPos);
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
        Debug.Log("IN");
        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        gameObject.GetComponent<SpriteRenderer>().color = tmp;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            Debug.Log("OUT");
            Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
            tmp.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = tmp;
        }
        
    }




}

public class Request : entry
{
    List<MessagesEntryPosition> messageEntryPos;
    List<Transform> arrayOfMessages;

    public Request(List<MessagesEntryPosition> messageSlotPos, List<Transform> messageArray)
    {
        messageEntryPos = messageSlotPos;
        arrayOfMessages = messageArray;
    }

    public override void SetMessageToSlot(Transform message)
    {
        for (int index = 0; index < messageEntryPos.Count; index++)
        {
            if (!messageEntryPos[index].slotIsAquired)
            {
                message.transform.position = messageEntryPos[index].messageSlot.transform.position;
                messageEntryPos[index].slotIsAquired = true;
                arrayOfMessages.Add(message);
                return;
            }


            if (arrayOfMessages.Count == 1)
            {
                ListIsFull = true;
            }
        }
    }

    public override void GiveMessageToPlayer(GameObject holder)
    {

        if (arrayOfMessages[0])
        {
            Debug.LogWarning("there is a message in first index ");
            if (!holder.GetComponentInParent<PlayerControls>().playerIsHoldingMessage)
            {
                Debug.LogWarning("NOOOO!!!!");
                holder.GetComponentInParent<PlayerControls>().playerIsHoldingMessage = true;


                //move message to player
                arrayOfMessages[0].transform.parent = holder.transform;
                arrayOfMessages[0].transform.position = holder.transform.position;
                holder.GetComponentInParent<PlayerControls>().playerIsHoldingMessage = true;
                messageEntryPos[0].slotIsAquired = false;
                
                ListIsFull = false;
                if (arrayOfMessages[1])
                {
                    Debug.Log("moving second message to first");
                    //moving second message to first slot
                    arrayOfMessages[1].transform.position = messageEntryPos[0].messageSlot.transform.position;
                    messageEntryPos[1].slotIsAquired = false;
                    messageEntryPos[0].slotIsAquired = true;
                }
                arrayOfMessages.Remove(arrayOfMessages[0]);
            }
            
        }
    }
}


public class Response: entry
{

    List<MessagesEntryPosition> messageEntryPos;
    List<Transform> arrayOfMessages;


    public Response(List<MessagesEntryPosition> messageSlotPos, List<Transform> messageArray)
    {
        messageEntryPos = messageSlotPos;
        arrayOfMessages = messageArray;
    }

    public override void SetMessageToSlot(Transform message)
    {
        if (!messageEntryPos[0].slotIsAquired)
        {
            Debug.LogWarning("WHAT THE HELL");
            Debug.Log("Setting Response Message");
            message.transform.position = messageEntryPos[0].messageSlot.transform.position;
            arrayOfMessages.Add(message);
            message.transform.parent = null;
            message.GetComponent<Message>().startedCreatingResponse = true;
            message.GetComponent<Message>().responseTimer.gameObject.SetActive(true);
            messageEntryPos[0].slotIsAquired = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().playerIsHoldingMessage = false;
        }
    }

    public override void GiveMessageToPlayer(GameObject holder)
    {
        if (arrayOfMessages[0])
        {
            if (arrayOfMessages[0].GetComponent<Message>().responseMessageIsReady)
            {
                messageEntryPos[0].slotIsAquired = false;
                arrayOfMessages[0].transform.position = holder.transform.position;
                arrayOfMessages[0].transform.parent = holder.transform;
                arrayOfMessages[0].GetComponent<Message>().ReadyText.gameObject.SetActive(false);
                arrayOfMessages[0].GetComponent<Message>().responseTimer.gameObject.SetActive(false);
                arrayOfMessages[0].GetComponent<Message>().MessageIsReady = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().playerIsHoldingMessage = true;
                arrayOfMessages.Remove(arrayOfMessages[0]);

            }

        }
    }
}

public class ResponseSender: entry
{
    List<MessagesEntryPosition> messageEntryPos;

    public ResponseSender(List<MessagesEntryPosition> messageSlotPos)
    {
        messageEntryPos = messageSlotPos;
    }

    public override void SetMessageToSlot(Transform message)
    {
        if (message.GetComponent<Message>().MessageIsReady)
        {
            Debug.Log("Sending!!!!");
            message.transform.parent = null;
            message.transform.position = messageEntryPos[0].messageSlot.transform.position;
            message.GetComponent<Message>().SendResponseToUser();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().playerIsHoldingMessage = false;
        } 
    }
}

public class MessageDestroyer: entry
 {


    List<MessagesEntryPosition> messageEntryPos;

    public MessageDestroyer(List<MessagesEntryPosition> messageSlotPos)
    {
        messageEntryPos = messageSlotPos;
    }

    public override void SetMessageToSlot(Transform message)
    {
        message.transform.parent = null;
        message.transform.position = messageEntryPos[0].messageSlot.transform.position;
        message.GetComponent<Message>().GetDestoryed();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().playerIsHoldingMessage = false;
        Debug.LogWarning(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().playerIsHoldingMessage = false);
    }
}



public class entry
{

    public bool ListIsFull;

    public entry()
    {
        ListIsFull = false;
    }

    public virtual void SetMessageToSlot(Transform message)
    {
       
    }

    public virtual void GiveMessageToPlayer(GameObject holder)
    {

    }
}