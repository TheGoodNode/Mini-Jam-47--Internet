using UnityEngine;

public class ResponseSenderEP : EntryPoint
{
void Start()
    {
        currentEntryPoint = EntryPointType.responseSender;
    }

    void Update()
    {
        
    }

    public override void SetMessageToSlot(GameObject message)
    {
        print("Set message from Response sender Entry Point");
    }

    public override void GetMessageFromSlot(GameObject message)
    {
        print("Give message to player from Response sender Entry point");
    }
}
