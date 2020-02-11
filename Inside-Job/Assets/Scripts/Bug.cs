using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{

    public Transform[] positions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPosition();
        checkIfReached();
    }

    float speed = 5;
    bool isMoving = false;
    Transform currentDestination;
    void MoveToPosition()
    {
        if (isMoving) return;
        Debug.Log("running");
        System.Random random = new System.Random();
        Transform pickPos = positions[random.Next(0, positions.Length - 1)];
        currentDestination = pickPos;
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, pickPos.position, step);
        isMoving = true;
    }

    void checkIfReached()
    {
        if(gameObject.transform.position == currentDestination.transform.position)
        {
            Debug.Log("DONNNEEE");
            isMoving = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            GameManager.instance.LoseGame();
        }
    }
}
