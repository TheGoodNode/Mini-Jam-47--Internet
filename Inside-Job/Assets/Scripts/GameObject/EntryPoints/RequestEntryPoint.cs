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

    public override void GetMessageFromSlot()
    {
        print("Give message to player from Request Entry point");
    }
}
