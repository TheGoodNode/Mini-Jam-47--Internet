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
    }

    private void Update()
    {

    }

    public float spawnDelay = 4;

    public IEnumerator CreateMessage()
    {

        while (GameManager.instance.gameIsOn)
        {
            yield return new WaitForSeconds(spawnDelay);

            System.Random random = new System.Random();
            int index = random.Next(0, EntryPoints.Length);
            EntryPoint randomEntry = EntryPoints[index].GetComponent<EntryPoint>();

            // if (!randomEntry.currentEntryPoint.ListIsFull)
            // {
            //     Transform message = Instantiate(messagePrefab).transform;
            //     randomEntry.currentEntryPoint.SetMessageToSlot(message);
            // }
        }
    }

    public void StopSpawning()
    {

    }
}
