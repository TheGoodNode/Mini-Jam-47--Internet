using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public TextMeshProUGUI amountResponseSentText;

    [HideInInspector]public int defaultAmountResponseSent = 0;

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
        instance.amountResponseSentText = GetComponent<GameObject>().GetComponent<TextMeshProUGUI>();
        instance.amountResponseSentText.text = $"Sent Response: {defaultAmountResponseSent}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementAmountResponseSent()
    {
        instance.defaultAmountResponseSent += 1;
        instance.amountResponseSentText.text = $"Sent Response: {instance.defaultAmountResponseSent}";
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
