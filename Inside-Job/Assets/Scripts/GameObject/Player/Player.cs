using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void Start()
    {

    }


    [HideInInspector] public bool playerIsOverEntryPoint = false;
    [HideInInspector] public bool playerIsHoldingMessage = false;
    [HideInInspector] public bool playerIsOverRequestEntryPoint = false;

    void Update()
    {
        if (playerIsOverEntryPoint)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("OVER HERE!!!" + playerIsHoldingMessage);
                if (!playerIsHoldingMessage)
                {
                    Debug.Log("Getting Message");
                    // selectedEntry.GiveMessageToPlayer(requestHolder);
                }
                else if (playerIsHoldingMessage && !playerIsOverRequestEntryPoint)
                {
                    Debug.Log("Setting Message");
                    // Transform message = requestHolder.transform.GetChild(0);
                    // selectedEntry.SetMessageToSlot(message);
                }
            }
        }
    }

    EntryPoint selectedEntry;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EntryPoint"))
        {
            playerIsOverEntryPoint = true;
            EntryPoint entryPoint = other.gameObject.GetComponent<EntryPoint>();
            selectedEntry = entryPoint;
            if (other.gameObject.tag == "RequestEntryPoint")
            {
                Debug.LogWarning("over request point");
                playerIsOverRequestEntryPoint = true;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EntryPoint"))
        {
            playerIsOverEntryPoint = false;
            playerIsOverRequestEntryPoint = false;
        }
    }

}
