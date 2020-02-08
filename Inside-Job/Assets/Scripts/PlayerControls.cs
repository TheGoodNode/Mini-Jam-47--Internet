using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{

    Rigidbody2D rigidbody2d;

    public float PlayerSpeed;

    public GameObject requestHolder;

    bool isHoldingRequest = false;

    [HideInInspector]
    public bool playerIsOverEntryPoint = false;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    [HideInInspector]
    public bool playerIsHoldingMessage = false;
    private void Update()
    {
        if (playerIsOverEntryPoint && !playerIsHoldingMessage)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Trying to hold the message");
                selectedEntry.currentEntryPoint.TakeMessage();
                selectedEntry.GiveMessageToPlayer(requestHolder);
                playerIsHoldingMessage = true;
            }

        }


        this.MovePlayer();

    }

   


    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        Vector2 position = rigidbody2d.position;

        position += move * PlayerSpeed * Time.deltaTime;
        rigidbody2d.MovePosition(position);

    }


    EntryPoint selectedEntry;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "EntryPoint")
        {
            playerIsOverEntryPoint = true;
            EntryPoint entryPoint = other.gameObject.GetComponent<EntryPoint>();
            selectedEntry = entryPoint;
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "EntryPoint")
        {
            playerIsOverEntryPoint = false;
        }
    }




}
