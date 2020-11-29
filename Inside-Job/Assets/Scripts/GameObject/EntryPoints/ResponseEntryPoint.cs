using System.Collections.Generic;
using UnityEngine;

public class ResponseEntryPoint : EntryPoint
{
    void Start()
    {
        currentEntryPoint = EntryPointType.response;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SetMessageToSlot(GameObject message)
    {
        if(ListIsFull) return;

        print("Set message from Response Entry Point");

        if(listOfMessages.Count >= maxSlots){
            ListIsFull = true;
        }
    }

    public override void GetMessageFromSlot(GameObject message)
    {
        if(checkIfHasMessages() == false) return;

        print("Give message to player from Response Entry point");

        if(listOfMessages.Count < maxSlots){
            ListIsFull = true;
        }
    }
}
