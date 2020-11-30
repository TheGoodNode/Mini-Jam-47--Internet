using UnityEngine;

public class RequestEntryPoint : EntryPoint
{
    void Start()
    {
        currentEntryPoint = EntryPointType.request;
    }

    void Update()
    {
        
    }

    public override void SetMessageToSlot(GameObject message)
    {
        if(CheckIfSlotsAreFull() == true) return;

        print("Set message from Request Entry Point");
    }

    public override void GetMessageFromSlot(GameObject message)
    {
        print("Give message to player from Request Entry point");
    }
}
