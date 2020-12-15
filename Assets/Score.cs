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
    int Time=60;
    void Start()
    {
        InvokeRepeating("TimeCountDown", 3, 1);
    }
    void TimeCountDown()
    {
        Time--;
        TimeText.text = Time.ToString();
        if (Time<1)
        {
            //GameOverUI.SetActive(true);
        }
    }
    public void ScoreUpdate()
    {
        PlayerScoreText.text = PlayerScore.ToString();
        CpuScoreText.text = CpuScore.ToString();
    }
}
