using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMessageEP : EntryPoint
{
   void Start()
    {
        currentEntryPoint = EntryPointType.messageDestroyer;
        SetMessageToSlot();
    }

    void Update()
    {
        
    }

    public override void SetMessageToSlot()
    {
        print("Set message from message detroy Entry Point");
    }

    public override void GiveMessageToPlayer()
    {
        print("Give message to player from message detroy Entry point");
    }
}
