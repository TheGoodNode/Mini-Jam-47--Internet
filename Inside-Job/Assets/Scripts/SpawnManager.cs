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
            yield return new WaitForSeconds(1f);

            System.Random random = new System.Random();
            int index = random.Next(0, EntryPoints.Length);
            EntryPoint randomEntry = EntryPoints[index].GetComponent<EntryPoint>();

            if (!randomEntry.currentEntryPoint.ListIsFull)
            {
                GameObject message = Instantiate(messagePrefab);
                randomEntry.currentEntryPoint.SetMessageToSlot(message);

                Debug.Log(message.GetComponent<Message>().messageText);
                Debug.Log(message.GetComponent<Message>().messageType);
            }
        }
    }
}
