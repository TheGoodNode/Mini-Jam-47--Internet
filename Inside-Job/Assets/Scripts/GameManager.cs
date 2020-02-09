using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    SpawnManager spawnManager;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if (instance != null)
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        Debug.Log("Game ended");
    }

    public void RestartGame()
    {
        spawnManager.StopAllCoroutines();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
