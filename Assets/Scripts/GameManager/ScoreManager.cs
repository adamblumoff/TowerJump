using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    private ScoreManager scoreManager;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        AddScore(1);
    }
    public void UpdateScore(int playerScore)
    {
        scoreText.text = "Score: " + playerScore;
    }
    public void AddScore(int points)
    {
        score += points;
        scoreManager.UpdateScore(score);
    }
}
