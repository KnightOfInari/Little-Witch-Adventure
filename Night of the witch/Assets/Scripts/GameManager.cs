using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;

    public GameObject UIcanvasPrefab;
    public GameObject GameOverUIPrefab;
    public GameObject playerPrefab;
    private GameObject playerInstance;

    private GameObject GUIInstance;


    [SerializeField]
    private float spawnTime = 2f;
    private float spawnTimePassed = 0;

    [SerializeField]
    private int startingLives = 3;

    public int currentLives;

    public int maxHealth = 3;
    public int currentHealth;

    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        currentLives = startingLives;
        currentHealth = maxHealth;
    }

    public void StartGame()
    {
        Debug.Log("starting a new game");
        currentLives = startingLives;
        playerInstance = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);
        GUIInstance = Instantiate(UIcanvasPrefab, Vector2.zero, Quaternion.identity);
        GUIInstance.SetActive(true);
        currentHealth = maxHealth;
    }

        public void HealPlayer(int healthAmmount)
    {
        if (currentHealth + healthAmmount <= maxHealth)
            currentHealth += healthAmmount;
        else
            currentHealth = maxHealth;
        GUIInstance.GetComponent<GUIScript>().HealthUpdate(currentHealth);

    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        GUIInstance.GetComponent<GUIScript>().HealthUpdate(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(playerInstance);
            RemoveLife();
        }
    }

    public void RemoveLife()
    {
        currentLives -= 1;
        if (currentLives <= 0)
            GameOver();
        else
        {
            playerInstance = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            currentHealth = maxHealth;
            GUIInstance.GetComponent<GUIScript>().HealthUpdate(currentHealth);
        }
    }

    public void GameOver()
    {
        GameOverUIPrefab.SetActive(true);
        GUIInstance.SetActive(false);
        Time.timeScale = 0f;
        
    }

    public void RestartOrContinue(bool restartOr)
    {
        if (restartOr == false)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            DestroyImmediate(playerInstance);
            StartGame();
        }
        else
        {
            SceneManager.LoadScene(1);
            DestroyImmediate(playerInstance);
            StartGame();
        }
        GameOverUIPrefab.SetActive(false);
        GUIInstance.SetActive(true);
        currentLives = startingLives;
        Time.timeScale = 1f;
    }

    public void QuitToMenu()
    {
        GameOverUIPrefab.SetActive(false);
        DestroyImmediate(playerInstance);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
    }
}
