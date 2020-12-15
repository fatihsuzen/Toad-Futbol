using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text PlayerScoreText, CpuScoreText;
    public Text TimeText;
    public int PlayerScore, CpuScore;
    public GameObject GameOverUI;
    public GameObject Ball;
    int Time=60;
    void Start()
    {
        InvokeRepeating("TimeCountDown", 3, 1);
    }
    void TimeCountDown()
    {
        if (Time < 1)
        {
            //GameOverUI.SetActive(true);
            //Ball.SetActive(false);
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
}
