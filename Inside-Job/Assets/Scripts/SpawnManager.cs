using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject messagePrefab;


    public Transform requestEntryPointHolder;
    private List<GameObject> allRequestEntryPoints;


    [HideInInspector]
    public bool gameIsOn = false;


    
    private void Start()
    {
        gameIsOn = true;

        allRequestEntryPoints = getAllRequestEntryPoints();
    }

    private List<GameObject> getAllRequestEntryPoints(){
        List<GameObject> tempArray = new List<GameObject>();

        foreach(Transform requestEntryPoint in requestEntryPointHolder){
            tempArray.Add(requestEntryPoint.gameObject);
        }

        return tempArray;
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
            int index = random.Next(0, allRequestEntryPoints.Count - 1);
            EntryPoint randomEntry = allRequestEntryPoints[index].GetComponent<RequestEntryPoint>();

            if (randomEntry.ListIsFull == false)
            {
                GameObject message = Instantiate(messagePrefab).gameObject;
                randomEntry.SetMessageToSlot(message);
            }
        }
    }

    public void StopSpawning()
    {

    }
}
