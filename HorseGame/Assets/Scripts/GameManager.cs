using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }
    private Player player;
    private Spawner spawner;

    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button retryButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI hiscoreText;
    public GameObject[] canUI;
    public int can = 3;

    public int currentIndex = 2;

    public float score;

    private int targetNumber; // Hedef sayi

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        NewGame();
    }
    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        SymbolController.Instance.GenerateProblem();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;
        can = 3;
        currentIndex = 2; 
        UpdateHiscore();

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        StartCoroutine(SembolSpawner.Instance.SpawnPrefabs());

        for (int i = 0; i < canUI.Length; i++)
        {
            canUI[i].SetActive(true);
        }
        //Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        //foreach (var obstacle in obstacles)
        //{
        //    Destroy(obstacle.gameObject);
        //}
        //score = 0f;
        //gameSpeed = initialGameSpeed;
        //enabled = true;

        //UpdateHiscore();

        //player.gameObject.SetActive(true);
        //spawner.gameObject.SetActive(true);
        //gameOverText.gameObject.SetActive(false);
        //retryButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    public void GameOver()
    {
        gameSpeed = 0;
        enabled = false;
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        StopAllCoroutines();

        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        UpdateHiscore();

        //gameSpeed = 0;
        //enabled = false;
        //player.gameObject.SetActive(false);
        //spawner.gameObject.SetActive(false);

        //gameOverText.gameObject.SetActive(true);
        //retryButton.gameObject.SetActive(true);

        //UpdateHiscore();
    }
    public void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }
        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }

    public void SetTargetNumber(int number)
    {
        targetNumber = number; // Hedef sayiyi belirleme
    }

    public void StartOperation(string operationTag)
    {
        // islemi baslatma
        Debug.Log("Operation started: " + operationTag + " - Target number: " + targetNumber);
    }
}

