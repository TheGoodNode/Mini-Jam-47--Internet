using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public TextMeshProUGUI amountResponseSentText;

    [HideInInspector] public int defaultAmountResponseSent = 0;

    public GameObject GameOverScreen;
    public GameObject WinScreen;
    public GameObject TutorialScreen;

    SpawnManager spawnManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    [HideInInspector] public bool gameIsOn = false;
    // Start is called before the first frame update
    void Start()
    {
        instance.TutorialScreen.SetActive(true);
        spawnManager = gameObject.GetComponent<SpawnManager>();
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

        if (instance.defaultAmountResponseSent >= 50)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        WinScreen.SetActive(true);
        gameIsOn = false;
    }



    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        gameIsOn = true;
        TutorialScreen.SetActive(false);
        StartCoroutine(spawnManager.CreateMessage());
    }

    public void LoseGame()
    {
        GameOverScreen.SetActive(true);
        gameIsOn = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
