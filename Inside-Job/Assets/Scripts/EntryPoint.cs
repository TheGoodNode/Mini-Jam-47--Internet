using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    
    public enum EntryPointType
    {
        request,
        response
    }

    public EntryPointType entryPointType;


    public entry currentEntryPoint;

    [System.Serializable]
    public class MessagesEntryPosition
    {
       public GameObject messageSlot;
       [HideInInspector]
       public bool slotIsAquired = false;
    }
    public List<MessagesEntryPosition> messageEntryPos;

    private void Awake()
    {
        
    }

    void Start()
    {
        switch (entryPointType)
        {
            case EntryPointType.request:
                currentEntryPoint = new Request();
                break;

            case EntryPointType.response:
               currentEntryPoint = new Response();
                break;

            default:
                break;
        }
    }

    public bool listIsFull = false;
    public List<GameObject> arrayOfMessages = new List<GameObject>(1);
    public void SetMessageToSlot(GameObject message)
    {
        for (int index = 0; index < messageEntryPos.Count ; index++)
        {
            if (!messageEntryPos[index].slotIsAquired)
            {
                message.transform.position = messageEntryPos[index].messageSlot.transform.position;
                messageEntryPos[index].slotIsAquired = true;
                arrayOfMessages.Add(message);
                return;
            }


            if(messageEntryPos.IndexOf(messageEntryPos[index]) == 0)
            {
                listIsFull = true;
            }
        }
    }

    public void GiveMessageToPlayer(GameObject holder)
    {
        if (arrayOfMessages[0] != null)
        {
            //move message to player
            arrayOfMessages[0].transform.parent = holder.transform;
            arrayOfMessages[0].transform.position = holder.transform.position;
            messageEntryPos[0].slotIsAquired = false;
            listIsFull = false;
            //if second is aquired
            if (arrayOfMessages[1])
            {
                //moving second message to first slot
                arrayOfMessages[1].transform.position = messageEntryPos[0].messageSlot.transform.position;
                messageEntryPos[1].slotIsAquired = false;
                messageEntryPos[0].slotIsAquired = true;

                arrayOfMessages.Remove(arrayOfMessages[0]);

            }
            //if second is empty
            else
            {
                messageEntryPos[0].slotIsAquired = false;
                arrayOfMessages.Remove(arrayOfMessages[0]);
            }
        }

    }


    public void HoldMessage()
    {

    }
}

public class Request: entry
{

    public override void SetMessage()
    {
        Debug.Log("Setting Request Message");
    }

    public override void TakeMessage()
    {
        Debug.Log("Taking Request Message");
    }
}


public class Response: entry
{
    public override void SetMessage()
    {
        Debug.Log("Setting Response Message");
    }

    public override void TakeMessage()
    {
        Debug.Log("Taking Response Message");
    }
}



public class entry
{

    public virtual void SetMessage()
    {
       
    }

    public virtual void TakeMessage()
    {

    }
}