using UnityEngine;

public class ResponseSenderEP : EntryPoint
{
void Start()
    {
        currentEntryPoint = EntryPointType.responseSender;
        SetMessageToSlot();
    }

    void Update()
    {
        
    }

    public override void SetMessageToSlot()
    {
        print("Set message from Response sender Entry Point");
    }

    public override void GetMessageFromSlot()
    {
        print("Give message to player from Response sender Entry point");
    }
}
