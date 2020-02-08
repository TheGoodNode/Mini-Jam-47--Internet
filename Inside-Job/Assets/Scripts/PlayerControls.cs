using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public float PlayerSpeed;

    public GameObject requestHolder;

    bool isHoldingRequest = false;




    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.MovePlayer();

        if (Input.GetKeyDown(KeyCode.E))
        {
            HoldRequest();
        }
    }

    private void HoldRequest()
    {
        if (isHoldingRequest)
        {
            Debug.Log("Started holding the request");
            isHoldingRequest = true;
        }
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        Vector2 position = rigidbody2d.position;

        position +=  move * PlayerSpeed * Time.deltaTime;
        rigidbody2d.MovePosition(position);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
    }
  

}
