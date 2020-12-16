using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text PlayerScoreText, CpuScoreText;
    public Text TimeText;
    public int PlayerScore, CpuScore;
    
    public GameObject Ball;
    public GameObject ScoreBoard;

    public GameObject GameOverUI;
    public Text GameOverUICpuScoreText;
    public Text GameOverUIPlayerNameText;

    int Time = 90;
    void Start()
    {
        InvokeRepeating("TimeCountDown", 3, 1);
    }
    void TimeCountDown()
    {
        if (Time < 1)
        {
            GameOverUI.SetActive(true);
            Ball.SetActive(false);
            ScoreBoard.SetActive(false);
            EndGame();
            return;
        }
        Time--;
        TimeText.text = Time.ToString();
    }
    public void ScoreUpdate()
    {
        PlayerScoreText.text = PlayerScore.ToString();
        CpuScoreText.text = CpuScore.ToString();
    }
    void EndGame()
    {
        GameOverUIPlayerNameText.text = PlayerScore.ToString();
        GameOverUICpuScoreText.text = CpuScore.ToString();
    }
}
