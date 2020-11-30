using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMessageEP : EntryPoint
{
   void Start()
    {
        currentEntryPoint = EntryPointType.messageDestroyer;
    }

    void Update()
    {
        
    }

    public override void SetMessageToSlot(GameObject message)
    {
        print("Set message from message detroy Entry Point");
    }

    public override void GetMessageFromSlot(GameObject message)
    {
        print("Give message to player from message detroy Entry point");
    }
}
