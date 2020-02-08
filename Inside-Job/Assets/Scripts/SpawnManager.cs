using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject messagePrefab;


    GameObject[] EntryPoints;

    [HideInInspector]
    public bool gameIsOn = false;

    private void Start()
    {
        gameIsOn = true;
        EntryPoints = GameObject.FindGameObjectsWithTag("RequestEntryPoint");
        StartCoroutine(CreateMessage());
    }

    private void Update()
    {

    }


    IEnumerator CreateMessage()
    {

        while (gameIsOn)
        {
            yield return new WaitForSeconds(3f);

            System.Random random = new System.Random();
            EntryPoint randomEntry = EntryPoints[random.Next(0, EntryPoints.Length)].GetComponent<EntryPoint>();

            if (!randomEntry.listIsFull)
            {
                GameObject message = Instantiate(messagePrefab);
                randomEntry.SetMessageToSlot(message);

                Debug.Log(message.GetComponent<Message>().messageText);
                Debug.Log(message.GetComponent<Message>().messageType);
            }
        }
    }
}
