using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour {

    public GameObject player;
    public GameObject[] hazard;
    public GameObject[] hazard2;
    public Vector3 spawnValues1;
    public Vector3 spawnValues2;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text livesText;
    public Text restartText;
    public Text gameOverText;
    public int timeDelay;

    private bool gameOver;
    private bool restart;
    private int score;
    private int lives;


    void Start()
    {
        Vector3 playerSpawnPosition = new Vector3(0, 0, 0);
        Quaternion playerSpawnRotation = Quaternion.identity;
        SetupShip();
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        lives = 3;
        score = 0;
        UpdateScore();
        UpdateLives();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                int spawnHazardIndex = Random.Range(0, hazard.Length);
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues1.x, spawnValues1.x), spawnValues1.y, spawnValues1.z);
                Vector3 spawnPosition2 = new Vector3(Random.Range(-spawnValues2.x, spawnValues2.x), spawnValues2.y, spawnValues2.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard[spawnHazardIndex], spawnPosition, spawnRotation);
                Instantiate(hazard2[spawnHazardIndex], spawnPosition2, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        PlayerPrefs.SetInt("Score", score);
    }

    void UpdateLives()
    {
        if (lives >= 0 ) {
            livesText.text = "Lives: " + lives;
        }
    }

    public void GameOver()
    {
        lives --;
        UpdateLives();
        if (lives > 0)
        {
            Invoke("SetupShip", timeDelay);
        }
        if (lives <= 0) {
            gameOverText.text = "Game Over!";
            gameOver = true;
        }
        
    }

    public void SetupShip()
    {
        Vector3 playerSpawnPosition = new Vector3(0, 0, 0);
        Quaternion playerSpawnRotation = Quaternion.identity;
        Instantiate(player, playerSpawnPosition, playerSpawnRotation);
    }
}
