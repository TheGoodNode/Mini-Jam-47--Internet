using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{

    Rigidbody2D rigidbody2d;

    public float PlayerSpeed;

    public GameObject requestHolder;

    [HideInInspector]
    public bool playerIsOverEntryPoint = false;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    [HideInInspector] public bool playerIsHoldingMessage = false;
    private void Update()
    {
        if (playerIsOverEntryPoint)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("OVER HERE!!!" + playerIsHoldingMessage);
                if (!playerIsHoldingMessage)
                {
                    Debug.Log("Getting Message");
                    selectedEntry.GiveMessageToPlayer(requestHolder);
                }
                else if(playerIsHoldingMessage && !playerIsOverRequestEntryPoint)
                {
                    Debug.Log("Setting Message");
                    Transform message = requestHolder.transform.GetChild(0);
                    selectedEntry.SetMessageToSlot(message);
                }
            }
        }
    }

    private void FixedUpdate()
    {
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


    entry selectedEntry;
    [HideInInspector] public bool playerIsOverRequestEntryPoint = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "EntryPoint")
        {
            playerIsOverEntryPoint = true;
            entry entryPoint = other.gameObject.GetComponent<EntryPoint>().currentEntryPoint;
            selectedEntry = entryPoint;
            if(other.gameObject.tag == "RequestEntryPoint")
            {
                Debug.LogWarning("over request point");
                playerIsOverRequestEntryPoint = true;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        

        if (other.gameObject.name == "EntryPoint")
        { 

            playerIsOverEntryPoint = false;
            playerIsOverRequestEntryPoint = false;
        }
    }




}
