using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Score : MonoBehaviour
{
    public Player player;

    public Text PlayerScoreText, CpuScoreText;
    public Text TimeText;
    public int PlayerScore, CpuScore;
    
    public GameObject Ball;
    public GameObject ScoreBoard;

    public GameObject GameOverUI;
    public Text GameOverUICpuScoreText;
    public Text GameOverUIPlayerNameText;

    public Text CoinText;
    public int Coin;

    public Text FansText;
    public int Fans=3;

    public Text FansTextGOUI;

    int Time = 5;
    int EndGameClaimCoin = 150;
    void Start()
    {
        InvokeRepeating("TimeCountDown", 3, 1);
        player.FansUpdate();
    }
    void TimeCountDown()
    {
        if (Time < 1)
        {            
            GameOverUI.SetActive(true);
            Ball.SetActive(false);
            ScoreBoard.SetActive(false);
            EndGame();
            CancelInvoke("TimeCountDown");
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
        GameOverClaimCoin();
    }
    void GameOverClaimCoin()
    {
        StartCoroutine(CoinCount(EndGameClaimCoin));
    }
    IEnumerator CoinCount(int money)
    {        
        while (Coin < money)
        {
            yield return new WaitForSeconds(0.05f);
            Coin +=5;
            CoinText.text = Coin.ToString();            
        }
        FansTextGOUI.text = Fans.ToString();
        player.SetMoney(EndGameClaimCoin);
        player.SetFans(Fans);
        

        StopCoroutine(CoinCount(EndGameClaimCoin));
    }
}
