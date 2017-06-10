using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Text scoreText;
    public int score;

	// Use this for initialization
	void Start () {
        score = PlayerPrefs.GetInt("Score");
        Debug.Log(score);
        scoreText.text = "Latest Score: " + score;
    }

    public void GameStart()
    {
        Application.LoadLevel("Main");
    }
}
