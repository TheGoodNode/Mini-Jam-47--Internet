﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestEntryPoint : EntryPoint
{
    void Start()
    {
        currentEntryPoint = EntryPointType.request;
        SetMessageToSlot();
    }

    void Update()
    {
        
    }

    public override void SetMessageToSlot()
    {
        print("Set message from Request Entry Point");
    }

    public override void GiveMessageToPlayer()
    {
        print("Give message to player from Request Entry point");
    }
}