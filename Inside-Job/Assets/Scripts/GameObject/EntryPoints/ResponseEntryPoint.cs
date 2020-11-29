using UnityEngine;

public class ResponseEntryPoint : EntryPoint
{
    void Start()
    {
        currentEntryPoint = EntryPointType.response;
        SetMessageToSlot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SetMessageToSlot()
    {
        print("Set message from Response Entry Point");
    }

    public override void GiveMessageToPlayer()
    {
        print("Give message to player from Response Entry point");
    }
}
